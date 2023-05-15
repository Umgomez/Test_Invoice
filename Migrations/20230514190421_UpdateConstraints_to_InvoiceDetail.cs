using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class UpdateConstraints_to_InvoiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_Price",
                table: "InvoiceDetail");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Qty",
                table: "InvoiceDetail");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Price",
                table: "InvoiceDetail",
                sql: "Price <> 0");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Qty",
                table: "InvoiceDetail",
                sql: "Qty <> 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_Price",
                table: "InvoiceDetail");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Qty",
                table: "InvoiceDetail");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Price",
                table: "InvoiceDetail",
                sql: "Price <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Qty",
                table: "InvoiceDetail",
                sql: "Qty <> ''");
        }
    }
}
