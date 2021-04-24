using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem.Controllers;
using VotingSystem.Data;
using VotingSystem.Models;

namespace UnitTestVotingSystem
{
    [TestClass]
    class UnitTestUsersController
    {
        private readonly VotingSystemContext context;

        /*
        * UsersController isn't able to be instantiated in a controller's usual way
        * Test below will not function until turned into true Controller form
        */

        //[TestMethod]
        //public void GetAllUsers_ReturnsUsers()
        //{

        //    var controller = new UsersController(context);;
        //    var result = controller.GetAllUsers;
        //    Assert.Something
        //}
    }
}
