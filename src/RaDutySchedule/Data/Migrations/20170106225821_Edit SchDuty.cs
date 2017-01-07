using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaDutySchedule.Data.Migrations
{
    public partial class EditSchDuty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "ScheduledDuties");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "ScheduledDuties",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "ScheduledDuties",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ScheduledDuties");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ScheduledDuties");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "ScheduledDuties",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
