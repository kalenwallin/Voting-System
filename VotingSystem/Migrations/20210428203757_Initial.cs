using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Election",
                columns: table => new
                {
                    ElectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Election", x => x.ElectionID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectionID = table.Column<int>(nullable: true),
                    Votes = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.CandidateID);
                    table.ForeignKey(
                        name: "FK_Candidate_Election_ElectionID",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectionID = table.Column<int>(nullable: true),
                    VotesFor = table.Column<int>(nullable: false),
                    VotesAgainst = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueID);
                    table.ForeignKey(
                        name: "FK_Issue_Election_ElectionID",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ballot",
                columns: table => new
                {
                    BallotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    ElectionID = table.Column<int>(nullable: true),
                    CandidateOneID = table.Column<int>(nullable: true),
                    CandidateTwoID = table.Column<int>(nullable: true),
                    IssueID = table.Column<int>(nullable: true),
                    VotedForIssue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ballot", x => x.BallotID);
                    table.ForeignKey(
                        name: "FK_Ballot_Candidate_CandidateOneID",
                        column: x => x.CandidateOneID,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ballot_Candidate_CandidateTwoID",
                        column: x => x.CandidateTwoID,
                        principalTable: "Candidate",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ballot_Election_ElectionID",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ballot_Issue_IssueID",
                        column: x => x.IssueID,
                        principalTable: "Issue",
                        principalColumn: "IssueID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ballot_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ballot_CandidateOneID",
                table: "Ballot",
                column: "CandidateOneID");

            migrationBuilder.CreateIndex(
                name: "IX_Ballot_CandidateTwoID",
                table: "Ballot",
                column: "CandidateTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ballot_ElectionID",
                table: "Ballot",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ballot_IssueID",
                table: "Ballot",
                column: "IssueID");

            migrationBuilder.CreateIndex(
                name: "IX_Ballot_UserID",
                table: "Ballot",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ElectionID",
                table: "Candidate",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_ElectionID",
                table: "Issue",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ballot");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Election");
        }
    }
}
