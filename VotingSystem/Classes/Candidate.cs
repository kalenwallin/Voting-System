using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Classes {

    public class Candidate {

        public int CandidateId { get; private set; }
        public string Name { get; private set; }
        public string Race { get; private set; }
        public int Votes { get; private set; }


        public Candidate (int candidateId, string name, string race, int votes) {
            CandidateId = candidateId;
            Name = name;
            Race = race;
            Votes = votes;
        }
    }
}
