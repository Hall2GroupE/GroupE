using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models
{
  public class Hall
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HallID { get; set; }

    [Required]
    [StringLength(100)]
    public string HallName { get; set; }

    [Required]
    public int Capacity { get; set; } // Maximum capacity of the hall

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal RentalCost { get; set; } // Cost per event or per hour

    [StringLength(100)]
    public string Location { get; set; }
  }
}
