using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class UserModels
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModels () {
            
        }

        public UserModels (string email, string password, string name) {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
