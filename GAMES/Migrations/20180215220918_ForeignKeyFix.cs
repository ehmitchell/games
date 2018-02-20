using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class ForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "TeamScore",
                newName: "TeamIdID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "TeamScore",
                newName: "GameIdID");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GameScoreOrder = table.Column<int>(nullable: false),
                    GameType = table.Column<int>(nullable: false),
                    IsTeamScore = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rules = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonScore",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    GameIdID = table.Column<Guid>(nullable: true),
                    PersonIdID = table.Column<Guid>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonScore", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonScore_Game_GameIdID",
                        column: x => x.GameIdID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonScore_Person_PersonIdID",
                        column: x => x.PersonIdID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamScore_GameIdID",
                table: "TeamScore",
                column: "GameIdID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamScore_TeamIdID",
                table: "TeamScore",
                column: "TeamIdID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonScore_GameIdID",
                table: "PersonScore",
                column: "GameIdID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonScore_PersonIdID",
                table: "PersonScore",
                column: "PersonIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamScore_Game_GameIdID",
                table: "TeamScore",
                column: "GameIdID",
                principalTable: "Game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamScore_Team_TeamIdID",
                table: "TeamScore",
                column: "TeamIdID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamScore_Game_GameIdID",
                table: "TeamScore");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamScore_Team_TeamIdID",
                table: "TeamScore");

            migrationBuilder.DropTable(
                name: "PersonScore");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_TeamScore_GameIdID",
                table: "TeamScore");

            migrationBuilder.DropIndex(
                name: "IX_TeamScore_TeamIdID",
                table: "TeamScore");

            migrationBuilder.RenameColumn(
                name: "TeamIdID",
                table: "TeamScore",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "GameIdID",
                table: "TeamScore",
                newName: "GameId");
        }
    }
}
