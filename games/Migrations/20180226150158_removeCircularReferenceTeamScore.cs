using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class removeCircularReferenceTeamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamScores_ID",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "TeamScores",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GamesInstances",
                nullable: false,
                defaultValue: new DateTime(2018, 2, 26, 9, 1, 57, 968, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 2, 26, 8, 57, 31, 91, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_TeamScores_TeamID",
                table: "TeamScores",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamScores_Teams_TeamID",
                table: "TeamScores",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamScores_Teams_TeamID",
                table: "TeamScores");

            migrationBuilder.DropIndex(
                name: "IX_TeamScores_TeamID",
                table: "TeamScores");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "TeamScores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GamesInstances",
                nullable: false,
                defaultValue: new DateTime(2018, 2, 26, 8, 57, 31, 91, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 2, 26, 9, 1, 57, 968, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamScores_ID",
                table: "Teams",
                column: "ID",
                principalTable: "TeamScores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
