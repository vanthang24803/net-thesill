using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.TheSill.Migrations
{
    /// <inheritdoc />
    public partial class updaterelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_UserEntityId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_UserEntityId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "roles");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "verify",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "RoleEntityUserEntity",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntityUserEntity", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntityUserEntity_UsersId",
                table: "RoleEntityUserEntity",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleEntityUserEntity");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "verify",
                table: "users");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "roles");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_UserEntityId",
                table: "roles",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_UserEntityId",
                table: "roles",
                column: "UserEntityId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
