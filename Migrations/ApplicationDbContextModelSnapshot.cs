﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Invoice.Data;

#nullable disable

namespace Test_Invoice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test_Invoice.Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Customer_ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CustomerStatus_ID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerType_ID")
                        .HasColumnType("int");

                    b.HasKey("Customer_ID");

                    b.HasIndex("CustomerStatus_ID");

                    b.HasIndex("CustomerType_ID");

                    b.HasIndex("CustomerName", "CustomerStatus_ID", "CustomerType_ID")
                        .IsUnique()
                        .HasDatabaseName("UQ_Customers");

                    b.ToTable("Customer", (string)null);

                    b.HasCheckConstraint("CHK_Address", "Address <> ''");

                    b.HasCheckConstraint("CHK_CustomerName", "CustomerName <> ''");
                });

            modelBuilder.Entity("Test_Invoice.Models.CustomerStatus", b =>
                {
                    b.Property<int>("CustomerStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerStatus_ID"), 1L, 1);

                    b.Property<string>("CustomerStatusDisplay")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("CustomerStatus_ID");

                    b.HasIndex("CustomerStatusDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_CustomerStatus");

                    b.ToTable("CustomerStatus", (string)null);

                    b.HasCheckConstraint("CHK_CustomerStatusDisplay", "CustomerStatusDisplay <> ''");

                    b.HasData(
                        new
                        {
                            CustomerStatus_ID = 1,
                            CustomerStatusDisplay = "Activo",
                            Order = 1
                        },
                        new
                        {
                            CustomerStatus_ID = 2,
                            CustomerStatusDisplay = "Inactivo",
                            Order = 2
                        });
                });

            modelBuilder.Entity("Test_Invoice.Models.CustomerType", b =>
                {
                    b.Property<int>("CustomerType_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerType_ID"), 1L, 1);

                    b.Property<string>("CustomerTypeDisplay")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("CustomerType_ID");

                    b.HasIndex("CustomerTypeDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_CustomerTypes");

                    b.ToTable("CustomerType", (string)null);

                    b.HasCheckConstraint("CHK_CustomerTypeDisplay", "CustomerTypeDisplay <> ''");

                    b.HasData(
                        new
                        {
                            CustomerType_ID = 1,
                            CustomerTypeDisplay = "Loyal",
                            Order = 1
                        },
                        new
                        {
                            CustomerType_ID = 2,
                            CustomerTypeDisplay = "Impulse",
                            Order = 2
                        },
                        new
                        {
                            CustomerType_ID = 3,
                            CustomerTypeDisplay = "Discount",
                            Order = 3
                        },
                        new
                        {
                            CustomerType_ID = 4,
                            CustomerTypeDisplay = "Need-based",
                            Order = 4
                        },
                        new
                        {
                            CustomerType_ID = 5,
                            CustomerTypeDisplay = "Wandering",
                            Order = 5
                        });
                });

            modelBuilder.Entity("Test_Invoice.Models.Invoice", b =>
                {
                    b.Property<int>("Invoice_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Invoice_ID"), 1L, 1);

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceDetail_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalItbis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Invoice_ID");

                    b.HasIndex("Customer_ID")
                        .IsUnique()
                        .HasDatabaseName("UQ_Invoices");

                    b.HasIndex("InvoiceDetail_ID");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Test_Invoice.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceDetail_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceDetail_ID"), 1L, 1);

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalItbis")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceDetail_ID");

                    b.HasIndex("Customer_ID")
                        .IsUnique()
                        .HasDatabaseName("UQ_InvoiceDetails");

                    b.ToTable("InvoiceDetail", (string)null);

                    b.HasCheckConstraint("CHK_Price", "Price <> ''");

                    b.HasCheckConstraint("CHK_Qty", "Qty <> ''");
                });

            modelBuilder.Entity("Test_Invoice.Models.Customer", b =>
                {
                    b.HasOne("Test_Invoice.Models.CustomerStatus", "CustomerStatus")
                        .WithMany()
                        .HasForeignKey("CustomerStatus_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Test_Invoice.Models.CustomerType", "CustomerTypes")
                        .WithMany()
                        .HasForeignKey("CustomerType_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerStatus");

                    b.Navigation("CustomerTypes");
                });

            modelBuilder.Entity("Test_Invoice.Models.Invoice", b =>
                {
                    b.HasOne("Test_Invoice.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Test_Invoice.Models.InvoiceDetail", "InvoiceDetails")
                        .WithMany()
                        .HasForeignKey("InvoiceDetail_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("Test_Invoice.Models.InvoiceDetail", b =>
                {
                    b.HasOne("Test_Invoice.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
