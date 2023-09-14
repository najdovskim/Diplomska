using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RaceId { get; set; }
        public string raceName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


        [ForeignKey("SeasonId")]
        [InverseProperty("Races")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        [ForeignKey("CircuitId")]
        public string CircuitId { get; set; }
        public Circuit Circuit { get; set; }

        public List<Result> Results { get; set; }

    }
}
