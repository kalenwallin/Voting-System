using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Models;

namespace VotingSystem.Data
{
    public class VotingSystemContext : DbContext
    {
        public VotingSystemContext (DbContextOptions<VotingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<VotingSystem.Models.UserModels> Users { get; set; }
        public DbSet<VotingSystem.Models.ElectionModels> Elections { get; set; }
        public DbSet<VotingSystem.Models.CandidateModels> Candidates { get; set; }
        public DbSet<VotingSystem.Models.IssueModels> Issues { get; set; }
        public DbSet<VotingSystem.Models.BallotModels> Ballots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModels>().ToTable("User")
                .HasKey(u => u.UserID);
            builder.Entity<UserModels>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            builder.Entity<ElectionModels>().ToTable("Election")
                .HasKey(e => e.ElectionID);
            builder.Entity<CandidateModels>().ToTable("Candidate")
                .HasKey(c => c.CandidateID);
            builder.Entity<IssueModels>().ToTable("Issue")
                .HasKey(i => i.IssueID);
            builder.Entity<BallotModels>().ToTable("Ballot")
                .HasKey(b => b.BallotID);
        }
    }
}
