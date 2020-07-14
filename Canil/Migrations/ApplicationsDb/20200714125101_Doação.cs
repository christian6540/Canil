using Microsoft.EntityFrameworkCore.Migrations;

namespace Canil.Migrations.ApplicationsDb
{
    public partial class Doação : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStocks_Products_ProductId",
                table: "OrderStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_StocksOnHold_Stock_StockId",
                table: "StocksOnHold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StocksOnHold",
                table: "StocksOnHold");

            migrationBuilder.RenameTable(
                name: "StocksOnHold",
                newName: "StockOnHold");

            migrationBuilder.RenameIndex(
                name: "IX_StocksOnHold_StockId",
                table: "StockOnHold",
                newName: "IX_StockOnHold_StockId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderStocks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockOnHold",
                table: "StockOnHold",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStocks_Products_ProductId",
                table: "OrderStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockOnHold_Stock_StockId",
                table: "StockOnHold",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStocks_Products_ProductId",
                table: "OrderStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_StockOnHold_Stock_StockId",
                table: "StockOnHold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockOnHold",
                table: "StockOnHold");

            migrationBuilder.RenameTable(
                name: "StockOnHold",
                newName: "StocksOnHold");

            migrationBuilder.RenameIndex(
                name: "IX_StockOnHold_StockId",
                table: "StocksOnHold",
                newName: "IX_StocksOnHold_StockId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderStocks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StocksOnHold",
                table: "StocksOnHold",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStocks_Products_ProductId",
                table: "OrderStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StocksOnHold_Stock_StockId",
                table: "StocksOnHold",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
