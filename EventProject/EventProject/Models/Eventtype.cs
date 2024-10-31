using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace events.Models
{
    public class Eventtype
    {
        [Key] // Marks this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment (IDENTITY)
        public int EventTypeID { get; set; }

        [Required] // NOT NULL constraint
        [StringLength(50)] // Limits length to NVARCHAR(50)
        public string EventTypeName { get; set; }

        [Required] // NOT NULL constraint
        [Column(TypeName = "decimal(10, 2)")] // DECIMAL(10,2) in the database
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; } = 0.00m; // Default value of 0.00

        [StringLength(250)] // NVARCHAR(250)
        public string Description { get; set; }
    }
}
