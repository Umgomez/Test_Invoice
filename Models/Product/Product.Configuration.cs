using Microsoft.EntityFrameworkCore;

namespace Test_Invoice.Models;

public class ProductConfiguration
{
    public static void Configure(ModelBuilder mb)
    {
        mb.Entity<Product>(opt =>
        {
            opt.ToTable("Product");
            opt.HasKey(x => x.Product_ID);
            opt.Property(x => x.Product_ID)
                .ValueGeneratedOnAdd();
            opt.Property(x => x.CodeProduct)
              .HasMaxLength(100);
            opt.Property(x => x.ProductName)
              .HasMaxLength(300);
            opt.Property(x => x.UnitPrice)
              .HasPrecision(18, 2);
            opt.Property(x => x.SalePrice)
              .HasPrecision(18, 2);

            #region Constraints
            opt.HasIndex(x => new { x.Product_ID, x.ProductName })
              .HasDatabaseName("UQ_Products")
              .IsUnique();
            #endregion

            #region Data
            opt.HasData(
              new Product { Product_ID = 1, CodeProduct = "EQ-1", ProductName = "Nevera LG 10pies", UnitPrice = Convert.ToDecimal("26254.54"), UnitsInStock = 408, SalePrice = Convert.ToDecimal("30192.72"), Discontinued = false },
              new Product { Product_ID = 2, CodeProduct = "EQ-2", ProductName = "Lavadora Nedoka", UnitPrice = Convert.ToDecimal("15500"), UnitsInStock = 602, SalePrice = Convert.ToDecimal("17825"), Discontinued = false },
              new Product { Product_ID = 3, CodeProduct = "EQ-3", ProductName = "Televisor 55 Pulgadas", UnitPrice = Convert.ToDecimal("36987.94"), UnitsInStock = 325, SalePrice = Convert.ToDecimal("42536.13"), Discontinued = false },
              new Product { Product_ID = 4, CodeProduct = "EQ-4", ProductName = "Abanico KDK pared", UnitPrice = Convert.ToDecimal("5465.43"), UnitsInStock = 365, SalePrice = Convert.ToDecimal("6285.25"), Discontinued = false },
              new Product { Product_ID = 5, CodeProduct = "EQ-5", ProductName = "Estufa 6 quemadores", UnitPrice = Convert.ToDecimal("21400.25"), UnitsInStock = 124, SalePrice = Convert.ToDecimal("24610.29"), Discontinued = false }
            );
            #endregion
        });

    }
}
