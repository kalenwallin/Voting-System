using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    public class UsersController
    {
        private readonly VotingSystemContext _context;

        public UsersController(VotingSystemContext context)
        {
            _context = context;
        }

        // Returns a list of all users
        public List<Classes.User> GetAllUsers()
        {
            List<Models.User> userListModel = _context.Users.ToList();
            List<Classes.User> userListClasses = new List<Classes.User>();

            foreach (Models.User user in userListModel) {
                userListClasses.Add( new Classes.User(int.Parse(user.UserID), user.Email, user.Password, user.Name, false) );
            }

            return userListClasses;
        }

        // Returns the user corresponding to the given id, if they exist
        public Classes.User GetUser(string id)
        {
            if (id == null) {
                return null;
            }

            Models.User user = _context.Users.FirstOrDefault(m => m.UserID == id);

            return new Classes.User(int.Parse(user.UserID), user.Email, user.Password, user.Name, false);
        }

        // Creates a new user
        public void Create(string email, string password, string name)
        {
            Models.User user = new Models.User(email, password, name);

            _context.Add(user);
            _context.SaveChanges();
        }

        // Edits an existing user by replacing it with the new given user
        // Returns true if the changes were successfully made
        public bool Edit(string id, Models.User user)
        {
            // Check that the user id's match.
            // This verifies that the new user given is based on the previous user
            if (id != user.UserID) {
                return false;
            }

            try {
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                if (!UserExists(user.UserID)) {
                    return false;
                }
                else {
                    throw e;
                }
            }

            return true;
        }

        // Deletes the user corresponding to the given id, if they exist
        public void Delete(string id)
        {
            if (id == null) {
                return;
            }

            Models.User user = _context.Users.FirstOrDefault(m => m.UserID == id);

            if (user == null) {
                return;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // Checks if a user corresponding to the given id exists
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
