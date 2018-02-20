using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class FixPeopleFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Person",
                newName: "TeamIdID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Team_TeamIdID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_TeamIdID",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "TeamIdID",
                table: "Person",
                newName: "TeamId");
        }
    }
}
