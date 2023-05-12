using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public class InvoiceDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceDetail_ID { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal TotalItbis { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }

    public int Customer_ID { get; set; }
    public Customer Customers { get; set; }
}
