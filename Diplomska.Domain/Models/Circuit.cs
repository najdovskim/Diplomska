using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomska.Domain.Models
{
    public class Circuit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string CircuitId { get; set; }
        public string CircuitName { get; set; }
        //public string Locality  { get; set; }
        //public string Country { get; set; }

        public List<Race> Races { get; set; }
    }
}
