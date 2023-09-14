using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Dtos
{
    public class RaceGetDto
    {
        public int RaceId { get; set; }
        public string raceName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
