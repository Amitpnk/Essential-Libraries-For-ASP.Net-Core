using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerEFCore.Data.Migrations
{
    public partial class modification_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrdersOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrdersOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersOrderId",
                table: "Products",
                column: "OrdersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrdersOrderId",
                table: "Products",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
