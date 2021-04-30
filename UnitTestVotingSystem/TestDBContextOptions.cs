using VotingSystem;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace UnitTestVotingSystem
{
    public class TestDBContextOptions : TestDB
    {
        public TestDBContextOptions()
            : base(
                new DbContextOptionsBuilder<VotingSystemContext>()
                    .UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=VotingSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options)
        {

        }
    }
}