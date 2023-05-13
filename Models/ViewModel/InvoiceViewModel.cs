namespace Test_Invoice.Models.ViewModel;

public class InvoiceViewModel
{
    public int Invoice_ID { get; set; }
    public decimal TotalItbis { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }

    public int Customer_ID { get; set; }

    public int InvoiceDetail_ID { get; set; }
}
