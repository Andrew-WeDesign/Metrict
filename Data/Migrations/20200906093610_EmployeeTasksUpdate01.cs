using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class EmployeeTasksUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserFullName",
                table: "EmployeeTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "EmployeeTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "EmployeeTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManagerFullName",
                table: "EmployeeTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_CompanyId",
                table: "EmployeeTasks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Company_CompanyId",
                table: "EmployeeTasks",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Company_CompanyId",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_CompanyId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserFullName",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ManagerFullName",
                table: "EmployeeTasks");
        }
    }
}
