using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Dtos
{
    public class ResultGetDto
    {
        public int numberId { get; set; }
        public int position { get; set; }
        public string positionText { get; set; }
        public int points { get; set; }
        public int grid { get; set; }
        public int laps { get; set; }
        public string status { get; set; }
        public string fastestLap { get; set; }
    }
}
