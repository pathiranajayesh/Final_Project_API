using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyEuropeJobs.Infrastructure.Migrations
{
    public partial class paymentfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "Billing",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "Billing",
                table: "Payment");
        }
    }
}
