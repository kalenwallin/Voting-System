using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Classes;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
    public static class BallotController
    {
        private static VotingSystemContext _context;


        public static void SetContext(VotingSystemContext context) {
            _context = context;
        }

        // Returns a ballot belonging to the given election and user-email, if it exists
        public static Ballot GetUserBallotFromElection(string email, int electionId) {
            UserModels user = _context.Users.FirstOrDefault(u => u.Email == email);

            // Return null if the user does not exist
            if (user == null) {
                return null;
            }

            return GetUserBallotFromElection(user.UserID, electionId);
        }

        // Returns a ballot belonging to the given election and user, if it exists
        public static Ballot GetUserBallotFromElection(int userId, int electionId) {
            BallotModels ballotModel = _context.Ballots.FirstOrDefault(b => b.UserID == userId && b.ElectionID == electionId);

            // Return null if the ballot does not exist
            if (ballotModel == null) {
                return null;
            }

            return BuildBallot(ballotModel);
        }

        // Returns a list of all ballots belonging to the user who has the given email
        public static List<Ballot> GetBallotsOfUser(string email) {
            UserModels user = _context.Users.FirstOrDefault(u => u.Email == email);

            // Return null if the user does not exist
            if (user == null) {
                return null;
            }

            return GetBallotsOfUser(user.UserID);
        }

        // Returns a list of all ballots belonging to the given userId
        public static List<Ballot> GetBallotsOfUser(int userId) {
            List<BallotModels> ballotModels = _context.Ballots.Where(b => b.UserID == userId).ToList();
            List<Ballot> ballots = new List<Ballot>();

            foreach (BallotModels bm in ballotModels) {
                ballots.Add(BuildBallot(bm));
            }

            return ballots;
        }

        // Returns a list of all ballots belonging to the given election
        public static List<Ballot> GetBallotsOfElection(int electionId) {
            List<BallotModels> ballotModels = _context.Ballots.Where(b => b.ElectionID == electionId).ToList();
            List<Ballot> ballots = new List<Ballot>();

            foreach (BallotModels bm in ballotModels)
            {
                ballots.Add(BuildBallot(bm));
            }

            return ballots;
        }

        // Returns the ballot corresponding to the given ballotId, if it exists
        public static Ballot GetBallot(int ballotId) {
            BallotModels ballotModel = _context.Ballots.FirstOrDefault(b => b.BallotID == ballotId);

            // Return null if the ballot does not exist
            if (ballotModel == null) {
                return null;
            }

            return BuildBallot(ballotModel);
        }

        // Creates a new ballot
        public static void Create(int userId, int electionId, Ballot ballot) {
            BallotModels newBallot = new BallotModels();
            List<IssueDecision> issues = IssuesController.GetIssuesInElection(electionId);

            newBallot.UserID = userId;
            newBallot.ElectionID = electionId;
            newBallot.CandidateOneID = ballot.Candidate1.CandidateId;
            newBallot.CandidateTwoID = ballot.Candidate2.CandidateId;
            newBallot.IssueID = issues[0].IssueId;
            newBallot.VotedForIssue = ballot.VotedYes;

            _context.Add(newBallot);
            _context.SaveChanges();
        }

        // Creates a new ballot after a user votes
        public static void Create(int userId, int electionId, string race1Vote, string race2Vote, bool issueVote)
        {
            BallotModels newBallot = new BallotModels();
            List<IssueDecision> issues = IssuesController.GetIssuesInElection(electionId);
            Election election = ElectionsController.GetElection(electionId);

            newBallot.UserID = userId;
            newBallot.ElectionID = electionId;

            Candidate CandidateOne = CandidatesController.GetCandidateByName(race1Vote);
            CandidatesController.voteInc(CandidateOne.CandidateId);
            newBallot.CandidateOneID = CandidateOne.CandidateId;

            Candidate CandidateTwo = CandidatesController.GetCandidateByName(race2Vote);
            CandidatesController.voteInc(CandidateTwo.CandidateId);
            newBallot.CandidateTwoID = CandidateTwo.CandidateId;

            newBallot.IssueID = issues[0].IssueId;
            IssuesController.voteInc(issues[0], issueVote);
            newBallot.VotedForIssue = issueVote;

            _context.Add(newBallot);
            _context.SaveChanges();
        }

        // Deletes the ballot with the given id, if it exists
        public static void Delete(int ballotId) {
            BallotModels ballot = _context.Ballots.FirstOrDefault(b => b.BallotID == ballotId);

            if (ballot == null) {
                return;
            }

            _context.Ballots.Remove(ballot);
            _context.SaveChanges();
        }

        // Checks if a ballot exists with the given id
        private static bool BallotExists(int id) {
            return _context.Ballots.Any(b => b.BallotID == id);
        }


        // Used by other methods in this class to build Ballot instances
        private static Ballot BuildBallot(BallotModels ballotModel) {
            Candidate candidate1 = CandidatesController.GetCandidate((int)ballotModel.CandidateOneID);
            Candidate candidate2 = CandidatesController.GetCandidate((int)ballotModel.CandidateTwoID);

            Ballot ballot = new Ballot(candidate1, candidate2, ballotModel.VotedForIssue);
            ballot.BallotId = (int)ballotModel.BallotID;
            ballot.UserId = (int)ballotModel.UserID;
            ballot.ElectionId = (int)ballotModel.ElectionID;
            ballot.IssueId = (int)ballotModel.IssueID;

            return ballot;
        }
    }
}
