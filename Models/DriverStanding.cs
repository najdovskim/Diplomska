using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonToDbTest.Models
{
    public class DriverStanding
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        public int Position { get; set; }
        public int positionText { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }

        [ForeignKey("Season")]
        public int SeasonsId { get; set; }
        public Season Season { get; set; }

        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        public Driver Driver { get; set; }

        [ForeignKey("ConstructorId")]
        public string ConstructorId { get; set; }
        public Constructor Constructor { get; set; }
    }
}
