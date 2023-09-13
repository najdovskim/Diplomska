using JsonToDbTest.Models;

namespace JsonToDbTest.RootTable
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
