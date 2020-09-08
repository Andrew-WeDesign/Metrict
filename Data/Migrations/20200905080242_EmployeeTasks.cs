using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class EmployeeTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ApplicationUserName = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true),
                    ManagerUserName = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Severity = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ManagerReply = table.Column<bool>(nullable: false),
                    EmployeeReply = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_ApplicationUserId",
                table: "EmployeeTasks",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTasks");
        }
    }
}
