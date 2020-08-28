using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class BackupDeletedreportsAndCampaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeletedCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    CampaignActive = table.Column<bool>(nullable: false),
                    ManagerId = table.Column<string>(nullable: true),
                    NumberDataColumnCount = table.Column<int>(nullable: false),
                    DataColumnNumber1Title = table.Column<string>(nullable: true),
                    DataColumnNumber2Title = table.Column<string>(nullable: true),
                    DataColumnNumber3Title = table.Column<string>(nullable: true),
                    DataColumnNumber4Title = table.Column<string>(nullable: true),
                    DataColumnNumber5Title = table.Column<string>(nullable: true),
                    DataColumnNumber6Title = table.Column<string>(nullable: true),
                    DataColumnNumber7Title = table.Column<string>(nullable: true),
                    DataColumnNumber8Title = table.Column<string>(nullable: true),
                    DataColumnNumber9Title = table.Column<string>(nullable: true),
                    DataColumnNumber10Title = table.Column<string>(nullable: true),
                    TextDataColumnCount = table.Column<int>(nullable: false),
                    DataColumnTextATitle = table.Column<string>(nullable: true),
                    DataColumnTextBTitle = table.Column<string>(nullable: true),
                    DataColumnTextCTitle = table.Column<string>(nullable: true),
                    DataColumnTextDTitle = table.Column<string>(nullable: true),
                    DataColumnTextETitle = table.Column<string>(nullable: true),
                    DataColumnTextFTitle = table.Column<string>(nullable: true),
                    DataColumnTextGTitle = table.Column<string>(nullable: true),
                    DataColumnTextHTitle = table.Column<string>(nullable: true),
                    DataColumnTextITitle = table.Column<string>(nullable: true),
                    DataColumnTextJTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeletedReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ApplicationUserName = table.Column<string>(nullable: true),
                    CampaignId = table.Column<int>(nullable: false),
                    CampaignName = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    DataColumnNumber1 = table.Column<int>(nullable: false),
                    DataColumnNumber2 = table.Column<int>(nullable: false),
                    DataColumnNumber3 = table.Column<int>(nullable: false),
                    DataColumnNumber4 = table.Column<int>(nullable: false),
                    DataColumnNumber5 = table.Column<int>(nullable: false),
                    DataColumnNumber6 = table.Column<int>(nullable: false),
                    DataColumnNumber7 = table.Column<int>(nullable: false),
                    DataColumnNumber8 = table.Column<int>(nullable: false),
                    DataColumnNumber9 = table.Column<int>(nullable: false),
                    DataColumnNumber10 = table.Column<int>(nullable: false),
                    DataColumnTextA = table.Column<string>(nullable: true),
                    DataColumnTextB = table.Column<string>(nullable: true),
                    DataColumnTextC = table.Column<string>(nullable: true),
                    DataColumnTextD = table.Column<string>(nullable: true),
                    DataColumnTextE = table.Column<string>(nullable: true),
                    DataColumnTextF = table.Column<string>(nullable: true),
                    DataColumnTextG = table.Column<string>(nullable: true),
                    DataColumnTextH = table.Column<string>(nullable: true),
                    DataColumnTextI = table.Column<string>(nullable: true),
                    DataColumnTextJ = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeletedCampaign");

            migrationBuilder.DropTable(
                name: "DeletedReport");
        }
    }
}
