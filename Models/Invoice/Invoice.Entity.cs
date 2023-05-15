using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Invoice_ID { get; set; }
    public decimal TotalItbis { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedDate { get; set; }

    public int Customer_ID { get; set; }
    public Customer Customers { get; set; }
}
