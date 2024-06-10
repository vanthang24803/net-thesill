using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.TheSill.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    avatar = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_name = table.Column<int>(type: "integer", maxLength: 255, nullable: false),
                    UserEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoleEntity_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_UserEntityId",
                table: "RoleEntity",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleEntity");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
