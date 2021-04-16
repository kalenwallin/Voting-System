using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    public static class UsersController
    {
        private static VotingSystemContext _context;


        public static void SetContext (VotingSystemContext context) {
            _context = context;
        }

        // Returns a list of all users
        public static List<Classes.User> GetAllUsers()
        {
            List<Models.User> userListModel = _context.Users.ToList();
            List<Classes.User> userListClasses = new List<Classes.User>();

            foreach (Models.User user in userListModel) {
                userListClasses.Add( new Classes.User(user.UserID, user.Email, user.Password, user.Name, false) );
            }

            return userListClasses;
        }

        // Returns the user corresponding to the given id, if they exist
        public static Classes.User GetUser(int id)
        {

            Models.User user = _context.Users.FirstOrDefault(m => m.UserID == id);

            return new Classes.User(user.UserID, user.Email, user.Password, user.Name, false);
        }

        // Returns the user corresponding to the given email, if they exist
        public static Classes.User GetUserByEmail(string email)
        {
            if (email == null) {
                return null;
            }

            Models.User user = _context.Users.FirstOrDefault(m => m.Email == email);

            return new Classes.User(user.UserID, user.Email, user.Password, user.Name, false);
        }

        // Creates a new user
        public static void Create(string email, string password, string name)
        {
            Models.User user = new Models.User(email, password, name);

            _context.Add(user);
            _context.SaveChanges();
        }

        // Edits an existing user by replacing it with the new given user
        // Returns true if the changes were successfully made
        public static bool Edit(int id, Classes.User user)
        {
            // Check that the user id's match.
            // This verifies that the new user given is based on the previous user
            if (id != user.UserId) {
                return false;
            }

            Models.User newUser = new Models.User(user.Email, user.Password, user.Name);
            newUser.UserID = user.UserId;

            try {
                _context.Update(newUser);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) {
                if (!UserExists(user.UserId)) {
                    return false;
                }
                else {
                    throw e;
                }
            }

            return true;
        }

        // Deletes the user corresponding to the given id, if they exist
        public static void Delete(int id)
        {

            Models.User user = _context.Users.FirstOrDefault(m => m.UserID == id);

            if (user == null) {
                return;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // Checks if a user corresponding to the given id exists
        private static bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
