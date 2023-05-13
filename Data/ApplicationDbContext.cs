using Microsoft.EntityFrameworkCore;
using Test_Invoice.Models;

namespace Test_Invoice.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerStatus> CustomerStatus { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CustomerConfiguration.Configure(modelBuilder);
        CustomerStatusConfiguration.Configure(modelBuilder);
        CustomerTypeConfiguration.Configure(modelBuilder);
        InvoiceConfiguration.Configure(modelBuilder);
        InvoiceDetailConfiguration.Configure(modelBuilder);
        ProductConfiguration.Configure(modelBuilder);

        base.OnModelCreating(modelBuilder);

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
