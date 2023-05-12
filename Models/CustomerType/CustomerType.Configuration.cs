using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class CustomerTypeConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<CustomerType>(opt =>
        {
            opt.ToTable("CustomerType");
            opt.HasKey(x => x.CustomerType_ID);
            opt.Property(x => x.CustomerType_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.CustomerTypeDisplay)
              .HasMaxLength(100);

            #region Constraints
            opt.HasIndex(x => new { x.CustomerTypeDisplay })
              .HasDatabaseName("UQ_CustomerTypes")
              .IsUnique();
            opt.HasCheckConstraint("CHK_CustomerTypeDisplay", "CustomerTypeDisplay <> ''");
            #endregion

            #region Data
            opt.HasData(
              new CustomerType { CustomerType_ID = 1, CustomerTypeDisplay = "Loyal", Order = 1 },
              new CustomerType { CustomerType_ID = 2, CustomerTypeDisplay = "Impulse", Order = 2 },
              new CustomerType { CustomerType_ID = 3, CustomerTypeDisplay = "Discount", Order = 3 },
              new CustomerType { CustomerType_ID = 4, CustomerTypeDisplay = "Need-based", Order = 4 },
              new CustomerType { CustomerType_ID = 5, CustomerTypeDisplay = "Wandering", Order = 5 }
            );
            #endregion
        });

    }
}
