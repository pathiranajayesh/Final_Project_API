using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyEuropeJobs.Infrastructure.Migrations
{
    public partial class UpdatedApplicantEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Applicant");

            migrationBuilder.CreateTable(
                name: "Applicant",
                schema: "Applicant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameWithInitials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NICNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    civilStatus = table.Column<int>(type: "int", nullable: false),
                    NumberOfDependants = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneMobile2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneFixed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_NICNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_PhoneMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse_AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_NICNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_PhoneMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_NICNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_PhoneMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicant_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicant",
                schema: "Applicant");
        }
    }
}
