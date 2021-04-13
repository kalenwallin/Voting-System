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

        public DbSet<VotingSystem.Models.User> Users { get; set; }
        public DbSet<VotingSystem.Models.Election> Elections { get; set; }
        public DbSet<VotingSystem.Models.Candidate> Candidates { get; set; }
        public DbSet<VotingSystem.Models.Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User")
                .HasKey(u => u.UserID);
            builder.Entity<Election>().ToTable("Election")
                .HasKey(e => e.ElectionID);
            builder.Entity<Candidate>().ToTable("Candidate")
                .HasKey(c => c.ElectionID);
            builder.Entity<Issue>().ToTable("Issue")
                .HasKey(i => i.ElectionID);
        }
    }
}
