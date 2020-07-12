using Microsoft.EntityFrameworkCore.Migrations;

namespace Canil.Migrations.ApplicationsDb
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adress2",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adress1",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeReference",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderStocks",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStocks", x => new { x.StockId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderStocks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderStocks_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_OrderId",
                table: "OrderStocks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStocks_ProductId",
                table: "OrderStocks",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStocks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StripeReference",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PostCode",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Adress2",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Adress1",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");
        }
    }
}
