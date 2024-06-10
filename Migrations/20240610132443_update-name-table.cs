using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.TheSill.Migrations
{
    /// <inheritdoc />
    public partial class updatenametable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleEntity_Users_UserEntityId",
                table: "RoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleEntity",
                table: "RoleEntity");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "RoleEntity",
                newName: "roles");

            migrationBuilder.RenameIndex(
                name: "IX_RoleEntity_UserEntityId",
                table: "roles",
                newName: "IX_roles_UserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_UserEntityId",
                table: "roles",
                column: "UserEntityId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_UserEntityId",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "RoleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_roles_UserEntityId",
                table: "RoleEntity",
                newName: "IX_RoleEntity_UserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleEntity",
                table: "RoleEntity",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleEntity_Users_UserEntityId",
                table: "RoleEntity",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
