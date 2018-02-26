using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GAMES.Migrations
{
    public partial class GamesInstanceDefaultTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "GamesInstances",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GamesInstances",
                nullable: false,
                defaultValue: new DateTime(2018, 2, 26, 8, 57, 31, 91, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 2, 26, 8, 50, 22, 604, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "GamesInstances",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GamesInstances",
                nullable: false,
                defaultValue: new DateTime(2018, 2, 26, 8, 50, 22, 604, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 2, 26, 8, 57, 31, 91, DateTimeKind.Local));
        }
    }
}
