using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class DriverStanding
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        public Constructor Constructor { get; set; }
    }
}
