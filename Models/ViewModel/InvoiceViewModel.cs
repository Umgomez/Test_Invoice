namespace Test_Invoice.Models.ViewModel;

public class InvoiceViewModel
{
    public int Customer_ID { get; set; }
    public decimal TotalItbis { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public List<InvoiceDetail> InvoiceDetails { get; set; }
    
    public int Qty { get; set; }
    public decimal Price { get; set; }
    //public DateTime CreatedDate { get; set; }
    
    public int Product_ID { get; set; }
    public string CodeProduct { get; set; }
    public string ProductName { get; set; }
}
