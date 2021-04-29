using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Classes;

namespace VotingSystem.Controllers
{
    public class ElectionsController
    {
        private static VotingSystemContext _context;

        public static void SetContext(VotingSystemContext context) {
            _context = context;
        }

        // Returns a list of all elections
        public static List<Election> GetAllElections(int electionId) {

            List<ElectionModels> electionModels = _context.Elections.ToList();
            List<Election> elections = new List<Election>();

            foreach (ElectionModels em in electionModels) {
                elections.Add( GetElection(em.ElectionID) );
            }

            return elections;
        }

        // Returns the election corresponding to the given electionId
        public static Election GetElection(int electionId) {
            ElectionModels em = _context.Elections.FirstOrDefault(e => e.ElectionID == electionId);

            // Return null if the election does not exist
            if (em == null) {
                return null;
            }

            List<string> races = GetElectionRaces(electionId);
            List<CandidateDecision> cDecisions = new List<CandidateDecision>();
            List<IssueDecision> iDecisions = IssuesController.GetIssuesInElection(electionId);

            Election election = new Election(em.Name, em.Date);
            election.ElectionId = electionId;

            // Add each race to the election
            foreach (string race in races) {
                List<Candidate> candidates = CandidatesController.GetCandidatesInRace(electionId, race);
                cDecisions.Add(new CandidateDecision(race, candidates[0], candidates[1]));
            }

            election.CandidateDecisions = cDecisions;
            election.IssueDecisions = iDecisions;

            return election;
        }

        // Returns a list of all races in the given election
        public static List<string> GetElectionRaces(int electionId) {
            // Return null if the election does not exist
            if (!ElectionExists(electionId)) {
                return null;
            }

            List<Candidate> candidates = CandidatesController.GetCandidatesInElection(electionId);
            List<string> raceNames = new List<string>();

            foreach (Candidate c in candidates) {
                if (!raceNames.Contains(c.Race)) {
                    raceNames.Add(c.Race);
                }
            }

            return raceNames;
        }

        // Creates a new Election, and new races and issues to go along with it
        public static void Create(Election election) {
            ElectionModels newElection = new ElectionModels();
            newElection.Name = election.ElectionName;
            newElection.Date = election.Date;

            _context.Add(newElection);
            _context.SaveChanges();

            newElection = _context.Elections.FirstOrDefault(e => e.Name == election.ElectionName && e.Date == election.Date);

            // Create candidate races
            foreach (CandidateDecision cd in election.CandidateDecisions) {
                CandidatesController.Create(cd.Candidate1.Name, cd.Candidate1.Race, newElection.ElectionID);
                CandidatesController.Create(cd.Candidate2.Name, cd.Candidate2.Race, newElection.ElectionID);
            }

            // Create issues
            foreach (IssueDecision isd in election.IssueDecisions) {
                IssuesController.Create(newElection.ElectionID, isd.Name, isd.Description);
            }
        }

        // Edits an existing election by replacing it with the new given election
        // Returns true if the changes were successfully made
        public static bool Edit(int electionId, Election election) {
            // Check that the election id's match.
            // This verifies that the new election given is based on the previous election
            if (electionId != election.ElectionId) {
                return false;
            }

            ElectionModels oldElection = _context.Elections.FirstOrDefault(c => c.ElectionID == electionId);

            // Cancel the edit if the candidate did not previously exist
            if (oldElection == null) {
                return false;
            }

            // Update the election's candidate races
            foreach (CandidateDecision cd in election.CandidateDecisions) {
                CandidatesController.Edit(cd.Candidate1.CandidateId, cd.Candidate1);
                CandidatesController.Edit(cd.Candidate2.CandidateId, cd.Candidate2);
            }

            // Update the election's issues
            foreach (IssueDecision isd in election.IssueDecisions) {
                IssuesController.Edit(isd.IssueId, isd);
            }

            ElectionModels newElection = new ElectionModels();
            newElection.Name = election.ElectionName;
            newElection.Date = election.Date;

            try {
                _context.Update(newElection);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                if (!ElectionExists(electionId)) {
                    return false;
                }
                else {
                    throw e;
                }
            }

            return true;
        }

        // Deletes the election corresponding to the given id, if it exists
        public static void Delete(int id) {

            ElectionModels election = _context.Elections.FirstOrDefault(m => m.ElectionID == id);

            if (election == null) {
                return;
            }

            _context.Elections.Remove(election);
            _context.SaveChanges();
        }

        public static bool ElectionExists(int id)
        {
            return _context.Elections.Any(e => e.ElectionID == id);
        }
    }
}
