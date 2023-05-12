using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public class CustomerStatus
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerStatus_ID { get; set; }
    public string CustomerStatusDisplay { get; set; }
    public int Order { get; set; }
}
