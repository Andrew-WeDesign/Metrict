using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrict.Migrations
{
    public partial class CompanyToReportAndCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Report",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Campaign",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Campaign");
        }
    }
}
