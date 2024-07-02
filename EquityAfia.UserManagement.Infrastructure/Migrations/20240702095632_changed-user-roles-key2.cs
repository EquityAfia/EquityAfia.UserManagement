using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeduserroleskey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_TableId",
                table: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "UserRoles",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_Id",
                table: "UserRoles",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_Id",
                table: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRoles",
                newName: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_TableId",
                table: "UserRoles",
                column: "TableId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
