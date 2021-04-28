using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Classes {

    public class IssueDecision {

        public int issueId;
        public string IssueName { get; private set; }
        public string Decription { get; private set; }
        public int VotesFor { get; private set; }
        public int VotesAgainst { get; private set; }
    }
}
