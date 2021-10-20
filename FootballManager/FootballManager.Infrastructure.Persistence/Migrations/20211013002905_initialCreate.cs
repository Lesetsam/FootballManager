using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballManager.Infrastructure.Persistence.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstValid = table.Column<DateTime>(nullable: false),
                    LastValid = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    IdNo = table.Column<long>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstValid = table.Column<DateTime>(nullable: false),
                    LastValid = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstValid = table.Column<DateTime>(nullable: false),
                    LastValid = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayerAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstValid = table.Column<DateTime>(nullable: false),
                    LastValid = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayerAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPlayerAssignments_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamPlayerAssignments_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamStadiumAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstValid = table.Column<DateTime>(nullable: false),
                    LastValid = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    StadiumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStadiumAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStadiumAssignment_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamStadiumAssignment_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayerAssignments_PlayerId",
                table: "TeamPlayerAssignments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayerAssignments_TeamId",
                table: "TeamPlayerAssignments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStadiumAssignment_StadiumId",
                table: "TeamStadiumAssignment",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStadiumAssignment_TeamId",
                table: "TeamStadiumAssignment",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamPlayerAssignments");

            migrationBuilder.DropTable(
                name: "TeamStadiumAssignment");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
