using Microsoft.EntityFrameworkCore.Migrations;

namespace EquityAfia.UserManagement.Infrastructure.Migrations
{
    public partial class MoveUserTypeLicenseNumberPractitionerTypeAfterPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PractitionerType",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PractitionerType",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PractitionerType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PractitionerType",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }
    }
}
