using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem.Controllers;
using VotingSystem.Data;
using VotingSystem.Models;

namespace UnitTestVotingSystem
{
    /*
     * Test classes Created and maintained by Cameron Collingham
     */
    [TestClass]
    public class UnitTestIssuesController
    {
        private readonly VotingSystemContext context;
        [TestMethod]
        public void Details_IfGivenNull_ShouldReturnNotFound()
        {
            var controller = new IssuesController(context);
            var result = controller.Details(null);
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void Edit_IfGivenNull_ShouldReturnNotFound()
        {
            var controller = new IssuesController(context);
            var result = controller.Edit(null);
            Assert.IsNotNull(result);
        }
    }
}
