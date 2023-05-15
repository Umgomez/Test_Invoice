using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class UpdateRelationships_InvoiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_InvoiceDetail_InvoiceDetail_ID",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_InvoiceDetail_ID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoiceDetail_ID",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "Invoice_ID",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_Invoice_ID",
                table: "InvoiceDetail",
                column: "Invoice_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoice_Invoice_ID",
                table: "InvoiceDetail",
                column: "Invoice_ID",
                principalTable: "Invoice",
                principalColumn: "Invoice_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoice_Invoice_ID",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_Invoice_ID",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "Invoice_ID",
                table: "InvoiceDetail");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetail_ID",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceDetail_ID",
                table: "Invoice",
                column: "InvoiceDetail_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceDetail_InvoiceDetail_ID",
                table: "Invoice",
                column: "InvoiceDetail_ID",
                principalTable: "InvoiceDetail",
                principalColumn: "InvoiceDetail_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
