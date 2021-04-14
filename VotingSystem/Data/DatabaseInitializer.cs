using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Models;

namespace VotingSystem.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDb(VotingSystemContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                //Makes sure there are users in the db
                return;
            }

            var users = new User[]
           {
                new User{Name="Tom Walton",Email="twalton4@huskers.unl.edu",Password="dummyvariable",UserID="tom2963"},
                new User{Name ="Kalen Wallin",Email ="kalenwallin@gmail.com",Password ="dummyvariable",UserID ="kalenwallin2"},
                new User{Name="Your Mom",Email="yourmom@yahoo.com",Password="yourmom",UserID="yourmom2" }
           };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();


            var elections = new Election[]
            {
                new Election{Open=true,Year=2021}
            };

            foreach (Election e in elections)
            {
                context.Elections.Add(e);
            }
            context.SaveChanges();


            var issues = new Issue[]
            {
                new Issue{Description="The Pacopolis Department of Recreation passed a bill, on January 21, 2021, to build a park on the corner of 1st street." +
                "The park will enter development if they receive a majoral vote in this election. If you are in favor of the city park, select yes. If not, select no."
                ,ElectionID=0001,Title="City Park",VotesAgainst=0,VotesFor=0}
            };

            foreach(Issue i in issues)
            {
                context.Issues.Add(i);
            }
            context.SaveChanges();

            var candidates = new Candidate[]
            {
                new Candidate{ElectionID=0001,Name="Pat Mann",Race="Mayoral Race",Votes=0},
                new Candidate{ElectionID=0001,Name="Dawn KeyKong",Race="Mayoral Race",Votes=0},
                new Candidate{ElectionID=0001,Name="John Doe",Race="Sheriff Election",Votes=0},
                new Candidate{ElectionID=0001,Name="Mary Jane",Race="Sheriff Election",Votes=0}
            };

            foreach(Candidate c in candidates)
            {
                context.Candidates.Add(c);
            }
            context.SaveChanges();

        }
    }
}
