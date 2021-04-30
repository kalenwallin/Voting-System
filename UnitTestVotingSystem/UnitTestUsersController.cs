using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem.Controllers;
using VotingSystem.Data;

namespace UnitTestVotingSystem
{
    [TestClass]
    class UnitTestUsersController
    {
        [TestMethod]
        public void Can_get_all_users()
        {
            UsersController.SetContext(new VotingSystemContext(new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options));

            List<VotingSystem.Classes.User> users = UsersController.GetAllUsers();

            Assert.Equals(2, users.Count);
        }
    }
}
