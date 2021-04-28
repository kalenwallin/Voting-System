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
            List<IssueDecision> iDecisions = new List<IssueDecision>();

            // TODO: Get actual name and date from the database
            Election election = new Election("Pacopolis Election", new DateTime(2021, 5, 8));

            // Add each race to the election
            foreach (string race in races) {
                List<Candidate> candidates = CandidatesController.GetCandidatesInRace(electionId, race);
                cDecisions.Add(new CandidateDecision(race, candidates[0], candidates[1]));
            }

            // TODO: Add issue to the election

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

        // Creates a new Election
        public static void Create(Election election) {
            
            // TODO: Implement this method
        }

        // Edits an existing election by replacing it with the new given election
        // Returns true if the changes were successfully made
        public static bool Edit(int electionId, Election election) {

            // TODO: Implement this method

            return false;
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
