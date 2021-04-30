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
    public class UnitTestBallotController
    {
        [TestMethod]
        public void Can_get_user_ballot_from_election_with_user_email()
        {
            InitializeDb();
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            Ballot b = BallotController.GetUserBallotFromElection("twalton4@huskers.unl.edu", 1);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Can_get_user_ballot_from_election_with_user_id()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            Ballot b = BallotController.GetUserBallotFromElection(1, 1);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Get_ballots_of_user_with_email()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Ballot> b = BallotController.GetBallotsOfUser("twalton4@huskers.unl.edu");
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Get_ballots_of_user_with_user_id()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Ballot> b = BallotController.GetBallotsOfUser(1);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Get_ballots_of_election_by_election_id()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Ballot> b = BallotController.GetBallotsOfElection(1);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Get_ballot_by_ballot_id()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            Ballot b = BallotController.GetBallot(1);
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void Create_ballot()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            Ballot b = new Ballot(new Candidate(1, "New Candidate 1", "Test Race", 0), 
                                  new Candidate(2, "New Candidate 2", "Test Race", 0), 
                                  false);
            List<Ballot> bBefore = BallotController.GetBallotsOfUser(1);
            BallotController.Create(1, 1, b);
            List<Ballot> bAfter = BallotController.GetBallotsOfUser(1);
            Assert.AreNotEqual(bBefore, bAfter);
        }

        [TestMethod]
        public void Create_ballot_from_user_vote()
        {
            BallotController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            CandidatesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            IssuesController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            ElectionsController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));
            List<Ballot> bBefore = BallotController.GetBallotsOfUser(2);
            BallotController.Create(2, 1, "Dawn KeyKong", "Mary Jane", true);
            List<Ballot> bAfter = BallotController.GetBallotsOfUser(2);
            Assert.AreNotEqual(bBefore, bAfter);
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
