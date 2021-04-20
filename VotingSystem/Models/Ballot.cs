using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class Ballot
    {
        public int BallotID { get; set; }
        public int UserId { get; set; }
        public int ElectionId { get; set; }
        public int RaceOneID { get; set; }
        public int RaceTwoID { get; set; }
        
        

    }
}