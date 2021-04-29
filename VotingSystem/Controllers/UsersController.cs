using System.Collections.Generic;
using System.Diagnostics;
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
            List<Models.UserModels> userListModel = _context.Users.ToList();
            List<Classes.User> userListClasses = new List<Classes.User>();

            foreach (Models.UserModels user in userListModel) {
                userListClasses.Add( new Classes.User(user.UserID, user.Email, user.Password, user.Name, false) );
            }

            return userListClasses;
        }

        // Returns the user corresponding to the given id, if they exist
        public static Classes.User GetUser(int id)
        {

            Models.UserModels user = _context.Users.FirstOrDefault(m => m.UserID == id);

            return new Classes.User(user.UserID, user.Email, user.Password, user.Name, false);
        }

        // Returns the user corresponding to the given email, if they exist
        public static Classes.User GetUserByEmail(string email)
        {
            if (email == null) {
                return null;
            }

            Models.UserModels user = _context.Users.FirstOrDefault(m => m.Email == email);
            if (user == null)
            {
                throw new System.Exception();
            }
            return new Classes.User(user.UserID, user.Email, user.Password, user.Name, false);
        }

        // Creates a new user
        public static void Create(string email, string password, string name)
        {
            Classes.User u = null;
            //get user by email if they exist
            try
            {
                u = GetUserByEmail(email);
            } catch (System.Exception e)
            {
                Debug.WriteLine(e);
            }
            
            //if user does not exist then add it to database
            if (u == null)
            {
                Models.UserModels user = new Models.UserModels(email, password, name);


                _context.Add(user);
                _context.SaveChanges();
            } else
            {
                throw new System.Exception();
            }
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

            Models.UserModels newUser = new Models.UserModels(user.Email, user.Password, user.Name);
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

            Models.UserModels user = _context.Users.FirstOrDefault(m => m.UserID == id);

            if (user == null) {
                return;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // Checks if the given user (by email) has voted in the given election
        public static bool HasUserVoted(string email, int electionId) {
            Models.UserModels user = _context.Users.FirstOrDefault(m => m.Email == email);

            return HasUserVoted(user.UserID, electionId);
        }

        // Checks if the given user has voted in the given election
        public static bool HasUserVoted(int userId, int electionId) {
            return _context.Ballots.Any(b => b.UserID == userId && b.ElectionID == electionId);
        }

        // Checks if a user corresponding to the given id exists
        private static bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
