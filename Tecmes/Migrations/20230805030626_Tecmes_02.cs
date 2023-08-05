using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tecmes.Migrations
{
    /// <inheritdoc />
    public partial class Tecmes_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user_tb",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user_tb",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_tb",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "sale_order_tb",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sale_order_tb",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductionOrderId",
                table: "sale_order_tb",
                newName: "production_order_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "sale_order_tb",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "sale_order_tb",
                newName: "is_completed");

            migrationBuilder.RenameIndex(
                name: "IX_sale_order_tb_ProductionOrderId",
                table: "sale_order_tb",
                newName: "IX_sale_order_tb_production_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_sale_order_tb_ProductId",
                table: "sale_order_tb",
                newName: "IX_sale_order_tb_product_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "production_order_tb",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "production_order_tb",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "QuantitySold",
                table: "production_order_tb",
                newName: "quantity_sold");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "production_order_tb",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "production_order_tb",
                newName: "is_completed");

            migrationBuilder.RenameIndex(
                name: "IX_production_order_tb_ProductId",
                table: "production_order_tb",
                newName: "IX_production_order_tb_product_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product_tb",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_tb",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "user_tb",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "user_tb",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user_tb",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "sale_order_tb",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "sale_order_tb",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "production_order_id",
                table: "sale_order_tb",
                newName: "ProductionOrderId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "sale_order_tb",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "is_completed",
                table: "sale_order_tb",
                newName: "IsCompleted");

            migrationBuilder.RenameIndex(
                name: "IX_sale_order_tb_production_order_id",
                table: "sale_order_tb",
                newName: "IX_sale_order_tb_ProductionOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_order_tb_product_id",
                table: "sale_order_tb",
                newName: "IX_sale_order_tb_ProductId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "production_order_tb",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "production_order_tb",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantity_sold",
                table: "production_order_tb",
                newName: "QuantitySold");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "production_order_tb",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "is_completed",
                table: "production_order_tb",
                newName: "IsCompleted");

            migrationBuilder.RenameIndex(
                name: "IX_production_order_tb_product_id",
                table: "production_order_tb",
                newName: "IX_production_order_tb_ProductId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "product_tb",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product_tb",
                newName: "Id");
        }
    }
}
