using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class CustomerConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<Customer>(opt =>
        {
            opt.ToTable("Customer");
            opt.HasKey(x => x.Customer_ID);
            opt.Property(x => x.Customer_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.CustomerName)
              .HasMaxLength(250);
            opt.Property(x => x.Address)
              .HasMaxLength(500);

            #region Constraints
            opt.HasIndex(x => new { x.CustomerName, x.CustomerStatus_ID, x.CustomerType_ID })
              .HasDatabaseName("UQ_Customers")
              .IsUnique();
            opt.HasCheckConstraint("CHK_CustomerName", "CustomerName <> ''");
            opt.HasCheckConstraint("CHK_Address", "Address <> ''");
            #endregion

            #region Relationships
            opt.HasOne(x => x.CustomerStatus)
              .WithMany()
              .HasForeignKey(x => x.CustomerStatus_ID);

            opt.HasOne(x => x.CustomerTypes)
              .WithMany()
              .HasForeignKey(x => x.CustomerType_ID);
            #endregion
        });

    }
}
