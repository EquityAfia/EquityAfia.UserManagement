using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityAfia.UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedthepractitionertypesfromenumtolist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PractitionerType",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PractitionerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PractitionerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PractitionerTypes_UserTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PractitionerTypes_Users_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTypes_PractitionerId",
                table: "PractitionerTypes",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTypes_TypeId",
                table: "PractitionerTypes",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PractitionerTypes");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerType",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
