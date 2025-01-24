using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiLogApi.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public float TotalCost { get; set; }

        /*[Required]
        [ForeignKey(nameof(Car))]
        public int CarID { get; set; }*/

        [Required]
        public int CarID { get; set; }

        [ForeignKey(nameof(CarID))]
        public virtual Car Car { get; set; }



    }
}
