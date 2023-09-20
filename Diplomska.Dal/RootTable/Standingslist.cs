using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.RootTable
{
    public class Standingslist
    {
        public string season { get; set; }
        public string round { get; set; }
        //public Driverstanding[] DriverStandings { get; set; }
        public List<DriverStanding> DriverStandings { get; set; }
    }
}
