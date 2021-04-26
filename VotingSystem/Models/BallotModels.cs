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
        public UserModels user { get; set; }

        public int? ElectionID { get; set; }
        public ElectionModels election { get; set; }

        public int? CandidateID { get; set; }
        public CandidateModels Candidate { get; set; }

        public int? IssueID { get; set; }
        public IssueModels issue { get; set; }
    }
}
