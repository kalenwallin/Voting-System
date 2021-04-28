using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Classes {

    /*
     * A class representing a race between two candidates
     * 
     * Josh Bellmyer    4/28/2021
     */
    public class CandidateDecision {

        public string DecisionName { get; private set; }
        public Candidate Candidate1 { get; private set; }
        public Candidate Candidate2 { get; private set; }

        public CandidateDecision (string decisionName, Candidate candidate1, Candidate candidate2) {
            DecisionName = decisionName;

            Candidate1 = candidate1;
            Candidate2 = candidate2;
        }

        public override string ToString () {
            return $"{DecisionName} ({Candidate1} vs {Candidate2})";
        }
    }
}
