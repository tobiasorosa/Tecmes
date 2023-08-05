using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tecmes.Migrations
{
    /// <inheritdoc />
    public partial class Tecmes_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FkSaleOrderTbXProductTb",
                table: "production_order_tb");

            migrationBuilder.AddForeignKey(
                name: "FkProductionOrderTbXProductTb",
                table: "production_order_tb",
                column: "product_id",
                principalTable: "product_tb",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FkProductionOrderTbXProductTb",
                table: "production_order_tb");

            migrationBuilder.AddForeignKey(
                name: "FkSaleOrderTbXProductTb",
                table: "production_order_tb",
                column: "product_id",
                principalTable: "production_order_tb",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
