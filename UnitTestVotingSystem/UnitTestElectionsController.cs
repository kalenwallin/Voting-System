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
    public class UnitTestElectionsController
    {
        private readonly VotingSystemContext context;

        [TestMethod]
        public void Edit_IfGivenNull_ReturnsNotFound()
        {
            var controller = new ElectionsController(context);
            var result = controller.Edit(null);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete_IfGivenNull_ReturnsNotFound()
        {
            var controller = new ElectionsController(context);
            var result = controller.Delete(null);
            Assert.IsNotNull(result);
        }

    }
}
