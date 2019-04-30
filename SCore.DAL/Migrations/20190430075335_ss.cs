using Microsoft.EntityFrameworkCore.Migrations;

namespace SCore.DAL.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Orders_OrderId",
                table: "Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Products_ProductId",
                table: "Lines");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Lines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Lines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Orders_OrderId",
                table: "Lines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Products_ProductId",
                table: "Lines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Orders_OrderId",
                table: "Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Products_ProductId",
                table: "Lines");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Lines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Lines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Orders_OrderId",
                table: "Lines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Products_ProductId",
                table: "Lines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
