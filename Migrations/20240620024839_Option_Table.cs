using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.TheSill.Migrations
{
    /// <inheritdoc />
    public partial class Option_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    option_price = table.Column<long>(type: "bigint", nullable: false),
                    option_quantity = table.Column<long>(type: "bigint", nullable: false),
                    option_sale = table.Column<int>(type: "integer", nullable: false),
                    ProductEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.id);
                    table.ForeignKey(
                        name: "FK_Options_Products_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_ProductEntityId",
                table: "Options",
                column: "ProductEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");
        }
    }
}
