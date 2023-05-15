namespace Test_Invoice.Models.ViewModel;

public class ProductViewModel
{
    public int Product_ID { get; set; }
    public string CodeProduct { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public decimal SalePrice { get; set; }
    public bool Discontinued { get; set; }

    public decimal PorcentajeGanancia { get; set; }
}
