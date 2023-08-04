using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tecmes.Migrations
{
    /// <inheritdoc />
    public partial class Tecmes_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "production_order_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    QuantitySold = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkProductionOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FkSaleOrderTbXProductTb",
                        column: x => x.ProductId,
                        principalTable: "production_order_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sale_order_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ProductionOrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkSaleOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FkSaleOrderTbXProductTb",
                        column: x => x.ProductId,
                        principalTable: "product_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FkSaleOrderTbXProductionOrderTb",
                        column: x => x.ProductionOrderId,
                        principalTable: "production_order_tb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_production_order_tb_ProductId",
                table: "production_order_tb",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_order_tb_ProductId",
                table: "sale_order_tb",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_order_tb_ProductionOrderId",
                table: "sale_order_tb",
                column: "ProductionOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale_order_tb");

            migrationBuilder.DropTable(
                name: "product_tb");

            migrationBuilder.DropTable(
                name: "production_order_tb");
        }
    }
}
