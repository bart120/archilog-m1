using ApiClassLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiLogApi.Models
{
    public class Reservation : BaseModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public float TotalCost { get; set; }

        [Required]
        public int CarID { get; set; }

        [ForeignKey(nameof(CarID))]
        public virtual Car Car { get; set; }



    }
}
