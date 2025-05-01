using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyEuropeJobs.Infrastructure.Migrations
{
    public partial class ApplicantNoteColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Applicant",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Applicant",
                table: "Applicant");
        }
    }
}
