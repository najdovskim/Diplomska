using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class Constructor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ConstructorId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }


        public List<DriverStanding> DriverStandings { get; set; }       
    }
}
