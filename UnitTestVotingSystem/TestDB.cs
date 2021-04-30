using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem.Controllers;
using VotingSystem.Data;
using VotingSystem.Models;


namespace UnitTestVotingSystem
{
    public abstract class TestDB
    {
        protected TestDB(DbContextOptions<VotingSystemContext> contextOptions)
        {
            ContextOptions = contextOptions;

            InitializeDb();
            //UsersController.SetContext(context);
            //ElectionsController.SetContext(context);
            //CandidatesController.SetContext(context);
            //IssuesController.SetContext(context);
            //BallotController.SetContext(context);
        }

        protected DbContextOptions<VotingSystemContext> ContextOptions { get; }
        private void InitializeDb()
        {
            using (var context = new VotingSystemContext(ContextOptions))
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
        public void Can_get_all_users()
        {
            using (var context = new VotingSystemContext(ContextOptions))
            {
                UsersController.SetContext(context);

                List<VotingSystem.Classes.User> users = UsersController.GetAllUsers();

                Assert.Equals(2, users.Count);
            }
        }
    }
}
