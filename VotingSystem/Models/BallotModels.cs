using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class BallotModels
    {
        public int BallotID { get; set; }
        public int? UserID { get; set; }
        public User user { get; set; }

        public int?ElectionID { get; set; }
        public Election election { get; set; }

        public int?CandidateID { get; set; }
        public Candidate candidate { get; set; }

        public int? IssueID { get; set; }
        public Issue issue { get; set; }
    }
}
