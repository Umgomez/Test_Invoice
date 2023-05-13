using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class InsertData_To_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Product_ID", "CodeProduct", "Discontinued", "ProductName", "SalePrice", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, "EQ-1", false, "Nevera LG 10pies", 30192.72m, 26254.54m, (short)408 },
                    { 2, "EQ-2", false, "Lavadora Nedoka", 17825m, 15500m, (short)602 },
                    { 3, "EQ-3", false, "Televisor 55 Pulgadas", 42536.13m, 36987.94m, (short)325 },
                    { 4, "EQ-4", false, "Abanico KDK pared", 6285.25m, 5465.43m, (short)365 },
                    { 5, "EQ-5", false, "Estufa 6 quemadores", 24610.29m, 21400.25m, (short)124 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Product_ID",
                keyValue: 5);
        }
    }
}
