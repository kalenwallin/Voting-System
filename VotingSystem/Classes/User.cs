using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace VotingSystem.Classes
    /*
     * class for containing user stuffs
     *
     * Cameron Collingham
     */
{
    public abstract class User
    {
        public abstract int UserId { get; set; }
        public abstract string Email  { get; set; }
        public abstract string Password { get; set; }

        //should be used to ensure accounts do not vote again (don't want no voter fraud you feel me?)
        public abstract bool HasVoted { get; set; }

        public User(int userId, string email, string password, bool hasVoted)
        {
            UserId = userId;
            Email = email;
            Password = password;
            HasVoted = hasVoted;
        }
    }
}
