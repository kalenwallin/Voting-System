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
     * 
     * Additional info from Kalen Wallin:
     * I've made the important info private
     * for Encapsulation's sake. 
     */
{
    public class User
    {
        private int UserId { get; set; }
        public int userId {
            get { return UserId; }
            set { UserId = userId; }
        }
        private string Email  { get; set; }
        public string email
        {
            get { return Email; }
            set { Email = email; }
        }
        private string Password { get; set; }
        public string password
        {
            get { return Password; }
            set { Password = password; }
        }
        public string Name { get; set; }

        //should be used to ensure accounts do not vote again (don't want no voter fraud you feel me?)
        public bool HasVoted { get; set; }

        public User(int userId, string email, string password, string name,  bool hasVoted)
        {
            UserId = userId;
            Email = email;
            Password = password;
            Name = name;
            HasVoted = hasVoted;
        }
    }
}
