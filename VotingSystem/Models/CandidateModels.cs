using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class CandidateModels
    {
        public int CandidateID { get; set; }
        public int? ElectionID { get; set; }
        public ElectionModels Election { get; set; }
        public int Votes { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }

    }
}
