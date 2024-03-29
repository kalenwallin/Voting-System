﻿using System;
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
    public static class CandidatesController
    {
        private static VotingSystemContext _context;

        public static void SetContext(VotingSystemContext context) { 
            _context = context;
        }

        // Returns a list of all candidates in the given election
        public static List<Candidate> GetCandidatesInElection(int electionId) {

            List<CandidateModels> candidateModels = _context.Candidates.Where(m => m.ElectionID == electionId).ToList();
            List<Candidate> candidates = new List<Candidate>();

            foreach (CandidateModels cm in candidateModels) {
                candidates.Add( new Candidate(cm.CandidateID, cm.Name, cm.Race, cm.Votes) );
            }

            return candidates;
        }

        // Returns a list containing the two candidates of a race, if the election exists
        public static List<Candidate> GetCandidatesInRace(int electionId, string race) {

            List<CandidateModels> candidateModels = _context.Candidates.Where(m => m.ElectionID == electionId && m.Race == race).ToList();

            // Return null if the election does not exist
            if (!ElectionsController.ElectionExists(electionId)) {
                return null;
            }

            // Return null if there aren't exactly two candidates in the race
            if (candidateModels.Count != 2) {
                return null;
            }

            List<Candidate> candidates = new List<Candidate>();

            foreach (CandidateModels cm in candidateModels)
            {
                candidates.Add(new Candidate(cm.CandidateID, cm.Name, cm.Race, cm.Votes));
            }

            return candidates;
        }

        // Returns the candidate with the given candidateId, if they exist
        public static Candidate GetCandidate(int candidateId)
        {
            CandidateModels candidateModel = _context.Candidates.FirstOrDefault(m => m.CandidateID == candidateId);

            return new Candidate(candidateModel.CandidateID, candidateModel.Name, candidateModel.Race, candidateModel.Votes);
        }

        // Returns the candidate with the given name, if they exist
        public static Candidate GetCandidateByName(string candidateName) {
            CandidateModels candidateModel = _context.Candidates.FirstOrDefault(m => m.Name == candidateName);

            return new Candidate(candidateModel.CandidateID, candidateModel.Name, candidateModel.Race, candidateModel.Votes);
        }

        // Creates a new candidate in the given election
        public static void Create(string name, string raceName, int electionId) {

            ElectionModels election = _context.Elections.FirstOrDefault(e => e.ElectionID == electionId);

            // Don't create the candidate if the election does not exist
            if (election == null) {
                return;
            }

            CandidateModels candidate = new CandidateModels(name, raceName, 0, electionId);

            _context.Add(candidate);
            _context.SaveChanges();
        }

        // Increments a candidates vote count by one
        public static void voteInc(int candidateId)
        {
            Candidate c = GetCandidate(candidateId);
            int votes = c.Votes;
            votes++;
            Candidate newC = new Candidate(candidateId, c.Name, c.Race, votes);
            Edit(candidateId, newC);
        }

        // Edits an existing candidate by replacing it with the new given candidate
        // Returns true if the changes were successfully made
        public static bool Edit(int candidateId, Candidate candidate) {
            // Check that the candidate id's match.
            // This verifies that the new candidate given is based on the previous candidate
            if (candidateId != candidate.CandidateId) {
                return false;
            }

            CandidateModels oldCandidate = _context.Candidates.FirstOrDefault(c => c.CandidateID == candidateId);

            // Cancel the edit if the candidate did not previously exist
            if (oldCandidate == null) {
                return false;
            }

            oldCandidate.Name = candidate.Name;
            oldCandidate.Race = candidate.Race;
            oldCandidate.Votes = candidate.Votes;

            try {
                _context.Update(oldCandidate);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CandidateExists(candidateId)) {
                    return false;
                }
                else {
                    throw e;
                }
            }

            return true;
        }

        // Deletes the candidate corresponding to the given id, if they exist
        public static void Delete(int candidateId) {
            CandidateModels candidate = _context.Candidates.FirstOrDefault(c => c.CandidateID == candidateId);

            if (candidate == null) {
                return;
            }

            _context.Candidates.Remove(candidate);
            _context.SaveChanges();
        }


        private static bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.CandidateID == id);
        }
    }
}
