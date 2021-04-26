using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class ElectionModels
    {
        public int ElectionID { get; set; }
        public int Year { get; set; }
        public bool Open { get; set; }
    }
}
