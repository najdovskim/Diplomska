using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Dtos
{
    public class DriverStandingGetDto
    {
        public int Position { get; set; }
        public int positionText { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int SeasonsId { get; set; }
        public string DriverId { get; set; }     
        public string ConstructorId { get; set; }
    }
}
