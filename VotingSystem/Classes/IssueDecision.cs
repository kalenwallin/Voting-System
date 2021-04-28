using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Classes {

    /*
     * A class representing an issue to be decided on in an election
     * 
     * Josh Bellmyer    4/28/2021
     */
    public class IssueDecision {

        public int IssueId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int VotesFor { get; private set; }
        public int VotesAgainst { get; private set; }

        public IssueDecision(int issueId, string name, string description, int votesFor, int votesAgainst) {
            IssueId = issueId;
            Name = name;
            Description = description;
            VotesFor = votesFor;
            VotesAgainst = votesAgainst;
        }
    }
}
