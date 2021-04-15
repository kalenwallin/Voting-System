using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Classes
{
    public static class signedIn
    {
        public static bool isSignedIn = false;

        public static bool setSigned(bool state)
        {
            return isSignedIn = state;
        }
    }
}
