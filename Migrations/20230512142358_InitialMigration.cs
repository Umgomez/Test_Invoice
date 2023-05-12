using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerStatus",
                columns: table => new
                {
                    CustomerStatus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerStatusDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStatus", x => x.CustomerStatus_ID);
                    table.CheckConstraint("CHK_CustomerStatusDisplay", "CustomerStatusDisplay <> ''");
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    CustomerType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.CustomerType_ID);
                    table.CheckConstraint("CHK_CustomerTypeDisplay", "CustomerTypeDisplay <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerStatus_ID = table.Column<int>(type: "int", nullable: false),
                    CustomerType_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_ID);
                    table.CheckConstraint("CHK_Address", "Address <> ''");
                    table.CheckConstraint("CHK_CustomerName", "CustomerName <> ''");
                    table.ForeignKey(
                        name: "FK_Customer_CustomerStatus_CustomerStatus_ID",
                        column: x => x.CustomerStatus_ID,
                        principalTable: "CustomerStatus",
                        principalColumn: "CustomerStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CustomerType_ID",
                        column: x => x.CustomerType_ID,
                        principalTable: "CustomerType",
                        principalColumn: "CustomerType_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceDetail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalItbis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.InvoiceDetail_ID);
                    table.CheckConstraint("CHK_Price", "Price <> ''");
                    table.CheckConstraint("CHK_Qty", "Qty <> ''");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Customer_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalItbis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDetail_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Invoice_ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceDetail_InvoiceDetail_ID",
                        column: x => x.InvoiceDetail_ID,
                        principalTable: "InvoiceDetail",
                        principalColumn: "InvoiceDetail_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CustomerStatus",
                columns: new[] { "CustomerStatus_ID", "CustomerStatusDisplay", "Order" },
                values: new object[,]
                {
                    { 1, "Activo", 1 },
                    { 2, "Inactivo", 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "CustomerType_ID", "CustomerTypeDisplay", "Order" },
                values: new object[,]
                {
                    { 1, "Loyal", 1 },
                    { 2, "Impulse", 2 },
                    { 3, "Discount", 3 },
                    { 4, "Need-based", 4 },
                    { 5, "Wandering", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerStatus_ID",
                table: "Customer",
                column: "CustomerStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerType_ID",
                table: "Customer",
                column: "CustomerType_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_Customers",
                table: "Customer",
                columns: new[] { "CustomerName", "CustomerStatus_ID", "CustomerType_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_CustomerStatus",
                table: "CustomerStatus",
                column: "CustomerStatusDisplay",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_CustomerTypes",
                table: "CustomerType",
                column: "CustomerTypeDisplay",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceDetail_ID",
                table: "Invoice",
                column: "InvoiceDetail_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_Invoices",
                table: "Invoice",
                column: "Customer_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_InvoiceDetails",
                table: "InvoiceDetail",
                column: "Customer_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerStatus");

            migrationBuilder.DropTable(
                name: "CustomerType");
        }
    }
}
