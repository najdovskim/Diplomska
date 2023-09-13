using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonToDbTest.Models
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
