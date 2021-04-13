﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingSystem.Data;

namespace VotingSystem.Migrations
{
    [DbContext(typeof(VotingSystemContext))]
    partial class VotingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VotingSystem.Models.Candidate", b =>
                {
                    b.Property<int>("ElectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("ElectionID");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("VotingSystem.Models.Election", b =>
                {
                    b.Property<int>("ElectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateElectionID")
                        .HasColumnType("int");

                    b.Property<int?>("IssueElectionID")
                        .HasColumnType("int");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ElectionID");

                    b.HasIndex("CandidateElectionID");

                    b.HasIndex("IssueElectionID");

                    b.ToTable("Election");
                });

            modelBuilder.Entity("VotingSystem.Models.Issue", b =>
                {
                    b.Property<int>("ElectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VotesAgainst")
                        .HasColumnType("int");

                    b.Property<int>("VotesFor")
                        .HasColumnType("int");

                    b.HasKey("ElectionID");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("VotingSystem.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VotingSystem.Models.Election", b =>
                {
                    b.HasOne("VotingSystem.Models.Candidate", null)
                        .WithMany("Elections")
                        .HasForeignKey("CandidateElectionID");

                    b.HasOne("VotingSystem.Models.Issue", null)
                        .WithMany("Elections")
                        .HasForeignKey("IssueElectionID");
                });
#pragma warning restore 612, 618
        }
    }
}