using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeasonId { get; set; }
        public List<Race> Races { get; set; }
        public List<DriverStanding> DriverStandings { get; set; }
    }
}
