using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class InsertData_to_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Customer_ID", "Address", "CustomerName", "CustomerStatus_ID", "CustomerType_ID" },
                values: new object[,]
                {
                    { 1, "Dirección del cliente 3", "José Miguel Calcaño", 1, 4 },
                    { 2, "Dirección del cliente 5", "María Peguero", 1, 2 },
                    { 3, "Dirección del cliente 6", "Juan Acosta", 2, 3 },
                    { 4, "Dirección del cliente 1", "Ramón Domínguez", 2, 5 },
                    { 5, "Dirección del cliente 5", "Pedro Almonte", 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Customer_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Customer_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Customer_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Customer_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Customer_ID",
                keyValue: 5);
        }
    }
}
