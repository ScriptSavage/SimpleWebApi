using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntityWarehouseProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    WarehouseProductProductId = table.Column<int>(type: "int", nullable: true),
                    WarehouseProductWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProducts", x => new { x.ProductId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_WarehouseProducts_WarehouseProductProductId_WarehouseProductWarehouseId",
                        columns: x => new { x.WarehouseProductProductId, x.WarehouseProductWarehouseId },
                        principalTable: "WarehouseProducts",
                        principalColumns: new[] { "ProductId", "WarehouseId" });
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProducts_WarehouseId",
                table: "WarehouseProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProducts_WarehouseProductProductId_WarehouseProductWarehouseId",
                table: "WarehouseProducts",
                columns: new[] { "WarehouseProductProductId", "WarehouseProductWarehouseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseProducts");
        }
    }
}
