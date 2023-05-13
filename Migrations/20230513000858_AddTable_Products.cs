using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class AddTable_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Product_ID",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeProduct = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_Product_ID",
                table: "InvoiceDetail",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_Products",
                table: "Product",
                columns: new[] { "Product_ID", "ProductName" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Product_Product_ID",
                table: "InvoiceDetail",
                column: "Product_ID",
                principalTable: "Product",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Product_Product_ID",
                table: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_Product_ID",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "Product_ID",
                table: "InvoiceDetail");
        }
    }
}
