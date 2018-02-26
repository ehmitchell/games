using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class database_refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamesInstances",
                columns: table => new
                {
                    GamesInstanceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PersonTeamSize = table.Column<int>(nullable: false),
                    Tagline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesInstances", x => x.GamesInstanceId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    IsTeamParticipant = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    GameScoreOrder = table.Column<int>(nullable: false),
                    GameType = table.Column<int>(nullable: false),
                    GamesInstanceId = table.Column<int>(nullable: true),
                    IsTeamScore = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rules = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_GamesInstances_GamesInstanceId",
                        column: x => x.GamesInstanceId,
                        principalTable: "GamesInstances",
                        principalColumn: "GamesInstanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonScores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GameID = table.Column<int>(nullable: true),
                    PersonID = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonScores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonScores_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonScores_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamScores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GameID = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamScores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamScores_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GamesInstanceId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_GamesInstances_GamesInstanceId",
                        column: x => x.GamesInstanceId,
                        principalTable: "GamesInstances",
                        principalColumn: "GamesInstanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_TeamScores_ID",
                        column: x => x.ID,
                        principalTable: "TeamScores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTeams",
                columns: table => new
                {
                    PersonTeamId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PersonID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTeams", x => x.PersonTeamId);
                    table.ForeignKey(
                        name: "FK_PersonTeams_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonTeams_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GamesInstanceId",
                table: "Games",
                column: "GamesInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonScores_GameID",
                table: "PersonScores",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonScores_PersonID",
                table: "PersonScores",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeams_PersonID",
                table: "PersonTeams",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeams_TeamID",
                table: "PersonTeams",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GamesInstanceId",
                table: "Teams",
                column: "GamesInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamScores_GameID",
                table: "TeamScores",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonScores");

            migrationBuilder.DropTable(
                name: "PersonTeams");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamScores");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GamesInstances");
        }
    }
}
