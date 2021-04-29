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
    public class IssuesController
    {
        private static VotingSystemContext _context;

        public static void SetContext(VotingSystemContext context) {
            _context = context;
        }

        // Returns all issues in the given election
        public static List<IssueDecision> GetIssuesInElection(int electionId) {
            List<IssueModels> issueModels = _context.Issues.Where(i => i.ElectionID == electionId).ToList();
            List<IssueDecision> issues = new List<IssueDecision>();

            foreach (IssueModels im in issueModels) {
                issues.Add( new IssueDecision(im.IssueID, im.Title, im.Description, im.VotesFor, im.VotesAgainst) );
            }

            return issues;
        }

        // Creates a new issue in the given election
        public static void Create(int electionId, string name, string description) {
            ElectionModels election = _context.Elections.FirstOrDefault(e => e.ElectionID == electionId);

            // Don't create the issue if the election doesn't exist
            if (election == null) {
                return;
            }

            IssueModels issue = new IssueModels(electionId, name, description);

            _context.Add(issue);
            _context.SaveChanges();
        }

        // Increments an issue's vote count by one given a user's vote
        public static void voteInc(IssueDecision issue, bool userVote)
        {
            int votesFor = issue.VotesFor;
            int votesAgainst = issue.VotesAgainst;
            if (userVote)
            {
                votesFor++;
            } else
            {
                votesAgainst++;
            }
            IssueDecision newI = new IssueDecision(issue.IssueId, issue.Name, issue.Description, votesFor, votesAgainst);
            Edit(issue.IssueId, newI);
        }

        // Edits an existing Issue by replacing it with the new given issue
        // Returns true if the changes were successfully made
        public static bool Edit(int issueId, IssueDecision issue) {
            // Check that the issue id's match.
            // This verifies that the new issue given is based on the previous issue
            if (issue.IssueId != issueId) {
                return false;
            }

            IssueModels oldIssue = _context.Issues.FirstOrDefault(i => i.IssueID == issueId);

            // Cancel the edit if the issue did not already exist
            if (oldIssue == null) {
                return false;
            }

            IssueModels newIssue = new IssueModels(oldIssue.ElectionID, issue.Name, issue.Description);
            newIssue.IssueID = issueId;
            newIssue.VotesFor = issue.VotesFor;
            newIssue.VotesAgainst = issue.VotesAgainst;

            try {
                _context.Update(newIssue);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                if (!IssueExists(issueId)) {
                    return false;
                }
                else {
                    throw e;
                }
            }

            return true;
        }

        // Deletes the issue corresponding to the given id, if it exists
        public static void Delete(int issueId)
        {
            IssueModels issue = _context.Issues.FirstOrDefault(c => c.IssueID == issueId);

            if (issue == null) {
                return;
            }

            _context.Issues.Remove(issue);
            _context.SaveChanges();
        }

        public static bool IssueExists(int id) {
            return _context.Issues.Any(e => e.IssueID == id);
        }
    }
}
