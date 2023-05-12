using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Customer_ID { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }

    public int CustomerStatus_ID { get; set; }
    public CustomerStatus CustomerStatus { get; set; }

    public int CustomerType_ID { get; set; }
    public CustomerType CustomerTypes { get; set; }
}
