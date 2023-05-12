using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Invoice.Models;

public class CustomerType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerType_ID { get; set; }
    public string CustomerTypeDisplay { get; set; }
    public int Order { get; set; }
}
