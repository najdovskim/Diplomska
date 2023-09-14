using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class DriverStandingRoot
    {
        public MRData MRData { get; set; }
    }

    public class DriverStandingTable
    {
        public List<DriverStanding> DriverStandings { get; set; }
    }
}
