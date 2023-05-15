using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class UpdateIndexConstraints_to_InvoiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_InvoiceDetails",
                table: "InvoiceDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_Customer_ID",
                table: "InvoiceDetail",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_InvoiceDetails",
                table: "InvoiceDetail",
                column: "InvoiceDetail_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_Customer_ID",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "UQ_InvoiceDetails",
                table: "InvoiceDetail");

            migrationBuilder.CreateIndex(
                name: "UQ_InvoiceDetails",
                table: "InvoiceDetail",
                column: "Customer_ID",
                unique: true);
        }
    }
}
