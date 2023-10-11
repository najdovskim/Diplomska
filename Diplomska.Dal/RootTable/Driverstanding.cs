using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.RootTable
{
    public class Driverstanding
    {
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }
        public string DriverId { get; set; }
        public Driver Driver { get; set; }
        public List<Constructor> Constructors { get; set; }
    }
}
