using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class EmployeeTaskStatusChanegTimeStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "EmployeeTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "EmployeeTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkInProgressDate",
                table: "EmployeeTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "WorkInProgressDate",
                table: "EmployeeTasks");
        }
    }
}
