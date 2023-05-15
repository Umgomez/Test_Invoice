using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Invoice.Migrations
{
    public partial class AddColumn_CreatedDete_to_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Invoice");
        }
    }
}
