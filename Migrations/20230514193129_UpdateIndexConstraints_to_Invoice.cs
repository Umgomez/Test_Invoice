using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class UpdateIndexConstraints_to_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Invoices",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Customer_ID",
                table: "Invoice",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_Invoices",
                table: "Invoice",
                column: "Invoice_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_Customer_ID",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "UQ_Invoices",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "UQ_Invoices",
                table: "Invoice",
                column: "Customer_ID",
                unique: true);
        }
    }
}
