using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class CustomerStatusConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<CustomerStatus>(opt =>
        {
            opt.ToTable("CustomerStatus");
            opt.HasKey(x => x.CustomerStatus_ID);
            opt.Property(x => x.CustomerStatus_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.CustomerStatusDisplay)
              .HasMaxLength(100);

            #region Constraints
            opt.HasIndex(x => new { x.CustomerStatusDisplay })
              .HasDatabaseName("UQ_CustomerStatus")
              .IsUnique();
            opt.HasCheckConstraint("CHK_CustomerStatusDisplay", "CustomerStatusDisplay <> ''");
            #endregion

            #region Data
            opt.HasData(
              new CustomerStatus { CustomerStatus_ID = 1, CustomerStatusDisplay = "Activo", Order = 1 },
              new CustomerStatus { CustomerStatus_ID = 2, CustomerStatusDisplay = "Inactivo", Order = 2 }
            );
            #endregion
        });

    }
}
