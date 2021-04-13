using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Candidate
    {
        public int ElectionID { get; set; }
        public int Votes { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        
        public ICollection<Election> Elections { get; set; }
    }
}
