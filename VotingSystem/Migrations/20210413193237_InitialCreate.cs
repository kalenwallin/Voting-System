using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    ElectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Votes = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.ElectionID);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    ElectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotesFor = table.Column<int>(nullable: false),
                    VotesAgainst = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.ElectionID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Election",
                columns: table => new
                {
                    ElectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Open = table.Column<bool>(nullable: false),
                    CandidateElectionID = table.Column<int>(nullable: true),
                    IssueElectionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Election", x => x.ElectionID);
                    table.ForeignKey(
                        name: "FK_Election_Candidate_CandidateElectionID",
                        column: x => x.CandidateElectionID,
                        principalTable: "Candidate",
                        principalColumn: "ElectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Election_Issue_IssueElectionID",
                        column: x => x.IssueElectionID,
                        principalTable: "Issue",
                        principalColumn: "ElectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Election_CandidateElectionID",
                table: "Election",
                column: "CandidateElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Election_IssueElectionID",
                table: "Election",
                column: "IssueElectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Election");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Issue");
        }
    }
}
