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
    public class UnitTestElectionsController
    {
        [TestMethod]
        public void Can_get_all_elections()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Election> elections = ElectionsController.GetAllElections(1);

            Assert.IsNotNull(elections);
        }

        [TestMethod]
        public void Can_get_election()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            Election election = ElectionsController.GetElection(1);
            Assert.IsNotNull(election);
        }

        [TestMethod]
        public void Can_get_election_races()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<string> races = ElectionsController.GetElectionRaces(1);
            Assert.AreEqual(races[0], "Mayoral Race");
        }

        [TestMethod]
        public void Can_create_election()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Election> eBefore = ElectionsController.GetAllElections(1);
            List<CandidateDecision> cd = new List<CandidateDecision>()
            {
                new CandidateDecision("New Race 1",
                    new Candidate(5, "New Candidate 1", "New Race 1", 0),
                    new Candidate(6, "New Candidate 2", "New Race 1", 0)),
                new CandidateDecision("New Race 2",
                    new Candidate(7, "New Candidate 1", "New Race 2", 0),
                    new Candidate(8, "New Candidate 2", "New Race 2", 0))
            };
            List<IssueDecision> id = new List<IssueDecision>()
            {
                new IssueDecision(2, "New Issue Name", "New Issue Description", 0, 0)
            };
            Election newElection = new Election("New Election Name", new DateTime(2021, 5, 1))
            {
                ElectionId = 3,
                CandidateDecisions = cd,
                IssueDecisions = id
            };
            ElectionsController.Create(newElection);
            List<Election> eAfter = ElectionsController.GetAllElections(1);
            Assert.AreNotEqual(eBefore.Count, eAfter.Count);
        }

        [TestMethod]
        public void Can_edit_election()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<CandidateDecision> cd = new List<CandidateDecision>()
            {
                new CandidateDecision("New Race 1",
                    new Candidate(5, "New Candidate 1", "New Race 1", 0),
                    new Candidate(6, "New Candidate 2", "New Race 1", 0)),
                new CandidateDecision("New Race 2",
                    new Candidate(7, "New Candidate 1", "New Race 2", 0),
                    new Candidate(8, "New Candidate 2", "New Race 2", 0))
            };
            List<IssueDecision> id = new List<IssueDecision>()
            {
                new IssueDecision(2, "New Issue Name", "New Issue Description", 0, 0)
            };
            Election newElection = new Election("New Election Name", new DateTime(2021, 5, 1))
            {
                ElectionId = 1,
                CandidateDecisions = cd,
                IssueDecisions = id
            };

            bool success = ElectionsController.Edit(1, newElection);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Does_election_exist()
        {
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            bool success = ElectionsController.ElectionExists(1);
            Assert.IsTrue(success);
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
