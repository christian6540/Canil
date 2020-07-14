using Microsoft.EntityFrameworkCore.Migrations;

namespace Canil.Migrations
{
    public partial class Doação2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CanilUserId",
                table: "Doação",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Doação_CanilUserId",
                table: "Doação",
                column: "CanilUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doação_AspNetUsers_CanilUserId",
                table: "Doação",
                column: "CanilUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doação_AspNetUsers_CanilUserId",
                table: "Doação");

            migrationBuilder.DropIndex(
                name: "IX_Doação_CanilUserId",
                table: "Doação");

            migrationBuilder.AlterColumn<int>(
                name: "CanilUserId",
                table: "Doação",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}