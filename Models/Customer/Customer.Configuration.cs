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

            #region Data
            opt.HasData(
              new Customer { Customer_ID = 1, CustomerName = "José Miguel Calcaño", Address = "Dirección del cliente 3", CustomerStatus_ID = 1, CustomerType_ID = 4 },
              new Customer { Customer_ID = 2, CustomerName = "María Peguero", Address = "Dirección del cliente 5", CustomerStatus_ID = 1, CustomerType_ID = 2 },
              new Customer { Customer_ID = 3, CustomerName = "Juan Acosta", Address = "Dirección del cliente 6", CustomerStatus_ID = 2, CustomerType_ID = 3 },
              new Customer { Customer_ID = 4, CustomerName = "Ramón Domínguez", Address = "Dirección del cliente 1", CustomerStatus_ID = 2, CustomerType_ID = 5 },
              new Customer { Customer_ID = 5, CustomerName = "Pedro Almonte", Address = "Dirección del cliente 5", CustomerStatus_ID = 1, CustomerType_ID = 1 }
            );
            #endregion
        });
    }
}
