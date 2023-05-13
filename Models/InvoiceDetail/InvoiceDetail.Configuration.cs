using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class InvoiceDetailConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<InvoiceDetail>(opt =>
        {
            opt.ToTable("InvoiceDetail");
            opt.HasKey(x => x.InvoiceDetail_ID);
            opt.Property(x => x.InvoiceDetail_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.Price)
              .HasPrecision(18, 2);
            opt.Property(x => x.TotalItbis)
              .HasPrecision(18, 2);
            opt.Property(x => x.SubTotal)
              .HasPrecision(18, 2);
            opt.Property(x => x.Total)
              .HasPrecision(18, 2);

            #region Constraints
            opt.HasIndex(x => new { x.Customer_ID })
              .HasDatabaseName("UQ_InvoiceDetails")
              .IsUnique();
            opt.HasCheckConstraint("CHK_Qty", "Qty <> ''");
            opt.HasCheckConstraint("CHK_Price", "Price <> ''");
            #endregion

            #region Relationships
            opt.HasOne(x => x.Customers)
              .WithMany()
              .HasForeignKey(x => x.Customer_ID);
            opt.HasOne(x => x.Products)
              .WithMany()
              .HasForeignKey(x => x.Product_ID);
            #endregion
        });

    }
}
