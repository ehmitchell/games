using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class reviseModelsForTeamsAndGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Team_TeamIdID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_TeamIdID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TeamIdID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "IsJudge",
                table: "Person",
                newName: "IsTeamParticipant");

            migrationBuilder.AddColumn<int>(
                name: "GamesInstanceId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesInstanceId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GamesInstance",
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
                    table.PrimaryKey("PK_GamesInstance", x => x.GamesInstanceId);
                });

            migrationBuilder.CreateTable(
                name: "PersonTeam",
                columns: table => new
                {
                    PersonTeamId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PersonID = table.Column<Guid>(nullable: true),
                    TeamID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTeam", x => x.PersonTeamId);
                    table.ForeignKey(
                        name: "FK_PersonTeam_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonTeam_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_GamesInstanceId",
                table: "Team",
                column: "GamesInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GamesInstanceId",
                table: "Game",
                column: "GamesInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeam_PersonID",
                table: "PersonTeam",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeam_TeamID",
                table: "PersonTeam",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_GamesInstance_GamesInstanceId",
                table: "Game",
                column: "GamesInstanceId",
                principalTable: "GamesInstance",
                principalColumn: "GamesInstanceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GamesInstance_GamesInstanceId",
                table: "Team",
                column: "GamesInstanceId",
                principalTable: "GamesInstance",
                principalColumn: "GamesInstanceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_GamesInstance_GamesInstanceId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GamesInstance_GamesInstanceId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "GamesInstance");

            migrationBuilder.DropTable(
                name: "PersonTeam");

            migrationBuilder.DropIndex(
                name: "IX_Team_GamesInstanceId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Game_GamesInstanceId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GamesInstanceId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "GamesInstanceId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "IsTeamParticipant",
                table: "Person",
                newName: "IsJudge");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamIdID",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_TeamIdID",
                table: "Person",
                column: "TeamIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Team_TeamIdID",
                table: "Person",
                column: "TeamIdID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
