using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class changeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeletedCampaign");

            migrationBuilder.DropTable(
                name: "DeletedReport");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Report",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Report");

            migrationBuilder.CreateTable(
                name: "DeletedCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignActive = table.Column<bool>(type: "bit", nullable: false),
                    DataColumnNumber10Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber4Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber5Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber6Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber7Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber8Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber9Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextATitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextBTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextCTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextDTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextETitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextFTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextGTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextHTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextITitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextJTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberDataColumnCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextDataColumnCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeletedReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnNumber1 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber10 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber2 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber3 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber4 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber5 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber6 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber7 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber8 = table.Column<int>(type: "int", nullable: false),
                    DataColumnNumber9 = table.Column<int>(type: "int", nullable: false),
                    DataColumnTextA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataColumnTextJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeletedReport_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeletedReport_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeletedReport_ApplicationUserId",
                table: "DeletedReport",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedReport_CampaignId",
                table: "DeletedReport",
                column: "CampaignId");
        }
    }
}
