using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class DriverStandingRoot
    {
        public MRData MRData { get; set; }
    }

    public class DriverStandingTable
    {
        public List<Standingslist> StandingsLists { get; set; }
    }

  /*  public class Standingstable
    {
        public string season { get; set; }
        public string round { get; set; }
        public Standingslist[] StandingsLists { get; set; }
    }
   */     

}
