using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace events.Models
{
  public class Events
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventID { get; set; }

    [Required]
    public int CustomerID { get; set; }

    [Required]
    public int NumberOfPeople { get; set; }

    [Required]
    public int HallID { get; set; }

    [Required]
    public int EventTypeID { get; set; }

    [Required]
    [StringLength(100)]
    public string EventName { get; set; }

    [Required]
    public int Hours { get; set; } // Duration of the event in hours

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime EventDate { get; set; }

    [Required]
    public string Status { get; set; } // Default status of the event

    [NotMapped] // This property will not be mapped to the database
    public decimal TotalCost
    {
      get
      {
        // Assuming you have a method to get the rental cost by HallID
        decimal rentalCost = GetRentalCostByHallID(HallID);
        return Hours * rentalCost;
      }
    }

    // Example method to fetch rental cost from a Hall (you should implement the logic)
    private decimal GetRentalCostByHallID(int hallId)
    {
      // Logic to get rental cost based on HallID
      // This is just a placeholder; replace with actual data retrieval logic
      return 100; // Example rental cost, replace as necessary
    }
  }
}
