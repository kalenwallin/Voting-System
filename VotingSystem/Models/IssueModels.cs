using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class IssueModels
    {
        public int IssueID { get; set; }
        public int? ElectionID { get; set; }
        public ElectionModels Election { get; set; }
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public IssueModels(int? electionID, string title, string description) {
            ElectionID = electionID;
            Title = title;
            Description = description;
            VotesFor = 0;
            VotesAgainst = 0;
        }
    }
}
