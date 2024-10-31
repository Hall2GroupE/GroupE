using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace events.Models
{
    public class Halls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HallID { get; set; }

        [Required]
        [StringLength(100)]
        public string HallName { get; set; }

        [Required]
        public int Capacity { get; set; } // Number of people the hall can accommodate


        public string Location { get; set; }
    }
}
