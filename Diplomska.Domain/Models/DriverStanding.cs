using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class DriverStanding
    {
        [Key]
        public int SeasonsId { get; set; } // Season ID
        [Key]
        public int Round { get; set; } // Round number
        [Key]
        public string DriverId { get; set; } // Driver ID

        public string Position { get; set; }
        public string positionText { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }

        [ForeignKey("SeasonsId")]
        public Season Season { get; set; }

        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        [ForeignKey("ConstructorId")]
        public string ConstructorId { get; set; }
        public Constructor Constructors { get; set; }



        /*  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          [Key]
          public int RoundId { get; set; }
          public string Position { get; set; }
          public string positionText { get; set; }
          public string Points { get; set; }
          public string Wins { get; set; }

          [ForeignKey("Season")]
          public int SeasonsId { get; set; }
          public Season Season { get; set; }

          [ForeignKey("Driver")]
          public string DriverId { get; set; }
          public Driver Driver { get; set; }

          [ForeignKey("ConstructorId")]
          public string ConstructorId { get; set; }
          public Constructor Constructors { get; set; }*/
    }
}
