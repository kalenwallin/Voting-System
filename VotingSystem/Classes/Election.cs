using System.Collections.Generic;
using System;

namespace VotingSystem.Classes {

    /*
     * A class representing an election
     * 
     * Josh Bellmyer    4/28/2021
     */
    public class Election {

        public string ElectionName { get; private set; }
        public DateTime Date { get; private set; }
        public List<CandidateDecision> CandidateDecisions { get; set; }
        public List<IssueDecision> IssueDecisions { get; set; }



        public Election (string electionName, DateTime date) {
            ElectionName = electionName;
            Date = date;
        }
    }
}
