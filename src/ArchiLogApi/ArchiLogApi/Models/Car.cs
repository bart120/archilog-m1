using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiLogApi.Models
{
    //[Table("voitures")] nom de la table si différent de DbSet
    public class Car
    {
        //[Key] pas obligatoire si le champ est ID en type int
        //[Column("IdCar")] renommer le champ en bdd
        public int ID { get; set; }

        [MaxLength(150)]
        [Required]
        public string Model { get; set; } = "";

        [MaxLength(150)]
        [Required]
        public string Brand { get; set; } = "";

        [Required]
        public float DailyRate { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public bool Deleted { get; set; }


    }
}
