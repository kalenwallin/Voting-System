using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem.Controllers;
using VotingSystem.Data;
using UnitTestVotingSystem;
using VotingSystem.Models;
using VotingSystem.Classes;

namespace UnitTestVotingSystem
{
    [TestClass]
    public class UnitTestIssuesController
    {
        [TestMethod]
        public void Can_get_all_issues_in_election()
        {
            InitializeDb();
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));

            List<IssueDecision> issueDecisions = IssuesController.GetIssuesInElection(1);

            Assert.AreEqual(1, issueDecisions.Count);
        }

        [TestMethod]
        public void Can_create_issue()
        {
            InitializeDb();
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<IssueDecision> isdBefore = IssuesController.GetIssuesInElection(1);
            IssuesController.Create(1, "Test Issue Name", "Test Issue Description");
            List<IssueDecision> isdAfter = IssuesController.GetIssuesInElection(1);
            Assert.AreNotEqual(isdBefore.Count, isdAfter.Count);
        }

        [TestMethod]
        public void Can_edit_issue()
        {
            InitializeDb();
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<IssueDecision> isdBefore = IssuesController.GetIssuesInElection(1);
            IssueDecision newI = new IssueDecision(1, "New Name", "New Desc", 0, 0);
            IssuesController.Edit(1, newI);
            List<IssueDecision> isdAfter = IssuesController.GetIssuesInElection(1);
            Assert.AreNotEqual(isdBefore[0].Name, isdAfter[0].Name);
        }

        [TestMethod]
        public void Can_increment_vote_of_issue()
        {
            InitializeDb();
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<IssueDecision> isdBefore = IssuesController.GetIssuesInElection(1);
            IssuesController.voteInc(isdBefore[0], true);
            List<IssueDecision> isdAfter = IssuesController.GetIssuesInElection(1);
            Assert.AreNotEqual(isdBefore[0].VotesFor, isdAfter[0].VotesFor);
        }

        public void InitializeDb()
        {
            using (var context = new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var users = new UserModels[]
               {
                    new UserModels{Name="Tom Walton",Email="twalton4@huskers.unl.edu",Password="dummyvariable"},
                    new UserModels{Name ="Kalen Wallin",Email ="kalenwallin@gmail.com",Password ="dummyvariable"}
               };

                foreach (UserModels u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();


                var elections = new ElectionModels[]
                {
                    new ElectionModels{Date=new DateTime(2022, 5, 7), Name="Some Future Election"},
                    new ElectionModels{Date=new DateTime(2021, 5, 7), Name="2021 Pacopolis Election"}
                };

                foreach (ElectionModels e in elections)
                {
                    context.Elections.Add(e);
                }
                context.SaveChanges();


                var issues = new IssueModels[]
                {
                    new IssueModels(0001, "City Park", "The Pacopolis Department of Recreation passed a bill, on January 21, 2021, to build a park on the corner of 1st street." +
                    " The park will enter development if they receive a majoral vote in this election. If you are in favor of the city park, select yes. If not, select no.")
                };

                foreach (IssueModels i in issues)
                {
                    context.Issues.Add(i);
                }
                context.SaveChanges();

                var candidates = new CandidateModels[]
                {
                    new CandidateModels{Name="Pat Mann",Race="Mayoral Race",Votes=0,ElectionID=0001},
                    new CandidateModels{Name="Dawn KeyKong",Race="Mayoral Race",Votes=0,ElectionID=0001},
                    new CandidateModels{Name="John Doe",Race="Sheriff Election",Votes=0,ElectionID=0001},
                    new CandidateModels{Name="Mary Jane",Race="Sheriff Election",Votes=0,ElectionID=0001}
                };

                foreach (CandidateModels c in candidates)
                {
                    context.Candidates.Add(c);
                }
                context.SaveChanges();

                var ballots = new BallotModels[]
                {
                    new BallotModels{CandidateOneID=1,CandidateTwoID=3,ElectionID=0001,IssueID=1,UserID=1,VotedForIssue=true}
                };

                foreach (BallotModels b in ballots)
                {
                    context.Ballots.Add(b);
                }
                context.SaveChanges();
            }
        }
    }
}
