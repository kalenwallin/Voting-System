using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User () {
            
        }

        public User (string email, string password, string name) {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
