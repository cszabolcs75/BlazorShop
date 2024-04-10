using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsAvailable", "ManufactureDate", "Name", "Price", "StockCount" },
                values: new object[] { 1, true, new DateTime(2024, 4, 9, 12, 47, 29, 385, DateTimeKind.Utc).AddTicks(5775), "Shoes", 500m, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsAvailable", "ManufactureDate", "Name", "Price", "StockCount" },
                values: new object[] { 2, true, new DateTime(2024, 4, 9, 12, 47, 29, 385, DateTimeKind.Utc).AddTicks(5779), "T-Shirt", 200m, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsAvailable", "ManufactureDate", "Name", "Price", "StockCount" },
                values: new object[] { 3, false, new DateTime(2024, 4, 9, 12, 47, 29, 385, DateTimeKind.Utc).AddTicks(5780), "Jeans", 600m, 80 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
