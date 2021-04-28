using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;


namespace VotingSystem.Controllers
{
    public static class BallotController
    {
        private static VotingSystemContext _context;


        public static void SetContext(VotingSystemContext context)
        {
            _context = context;
        }

        
    }
}
