using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaDutySchedule.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    DutyID = table.Column<string>(nullable: false),
                    DutyDate = table.Column<DateTime>(nullable: false),
                    aubgID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.DutyID);
                });

            migrationBuilder.AddColumn<string>(
                name: "aubgID",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aubgID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Duties");
        }
    }
}
