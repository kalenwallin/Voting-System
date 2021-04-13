using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Issue
    {
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ElectionID { get; set; }
    }
}
