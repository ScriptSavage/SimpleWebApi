using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WarehouseId",
                table: "Orders",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Warehouse_WarehouseId",
                table: "Orders",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Warehouse_WarehouseId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WarehouseId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Orders");
        }
    }
}
