using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using VotingSystem.Controllers;
using VotingSystem.Data;
using UnitTestVotingSystem;
using VotingSystem.Classes;
using VotingSystem.Models;

namespace UnitTestVotingSystem
{
    [TestClass]
    public class UnitTestUsersController
    {
        [TestMethod]
        public void Can_get_all_users()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));

            List<VotingSystem.Classes.User> users = UsersController.GetAllUsers();

            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void GetUser_ReturnsUser()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options));

            var user = UsersController.GetUser(1);
            var name = "Tom Walton";
            Assert.AreEqual(name, user.Name);
        }

        [TestMethod]
        public void GetUserByEmail_ReturnsUser()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options));

            var user = UsersController.GetUserByEmail("twalton4@huskers.unl.edu");
            var name = "Tom Walton";
            Assert.AreEqual(name, user.Name);
        }

        [TestMethod]
        public void GetUserByEmail_ReturnsNull_GivenNull()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options));
            var user = UsersController.GetUserByEmail(null);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void Create_Creates()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options));
            UsersController.Create("Entity@gmail.com", "securepassword", "Entity");
            var suspect = UsersController.GetUserByEmail("Entity@gmail.com");
            Assert.IsNotNull(suspect);
        }

        [TestMethod]
        public void Edit_Edits_GivenValid()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options));

            UsersController.Create("Entity2@gmail.com", "securepassword2", "Entity2");
            var oldUser = UsersController.GetUserByEmail("Entity2@gmail.com");
            Assert.IsTrue(UsersController.Edit(oldUser.UserId, oldUser));
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
                    // new IssueModels{Description="The Pacopolis Department of Recreation passed a bill, on January 21, 2021, to build a park on the corner of 1st street." +
                    // "The park will enter development if they receive a majoral vote in this election. If you are in favor of the city park, select yes. If not, select no."
                    // ,Title="City Park",VotesAgainst=0,VotesFor=0, ElectionID=0001}

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
