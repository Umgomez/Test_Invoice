using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class InvoiceConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<Invoice>(opt =>
        {
            opt.ToTable("Invoice");
            opt.HasKey(x => x.Invoice_ID);
            opt.Property(x => x.Invoice_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.TotalItbis)
              .HasPrecision(18, 2);
            opt.Property(x => x.SubTotal)
              .HasPrecision(18, 2);
            opt.Property(x => x.Total)
              .HasPrecision(18, 2);

            #region Constraints
            opt.HasIndex(x => new { x.Customer_ID })
              .HasDatabaseName("UQ_Invoices")
              .IsUnique();
            #endregion

            #region Relationships
            opt.HasOne(x => x.Customers)
              .WithMany()
              .HasForeignKey(x => x.Customer_ID);
            opt.HasOne(x => x.InvoiceDetails)
              .WithMany()
              .HasForeignKey(x => x.InvoiceDetail_ID);
            #endregion
        });

    }
}
