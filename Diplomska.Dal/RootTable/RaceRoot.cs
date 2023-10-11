
using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class RaceRoot
    {
        public MRData MRData { get; set; }
    }

    public class RaceTable
    {
        public string Season { get; set; }
        public List<RRace> Races { get; set; }
    }

    public class RRace
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public string RaceName { get; set; }
        public CCircuit Circuit { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class CCircuit
    {
        public string CircuitId { get; set; }
        public string CircuitName { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }

}
