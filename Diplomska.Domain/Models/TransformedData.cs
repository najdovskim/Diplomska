using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Domain.Models
{
    public class TransformedData
    {
        public string DriverId { get; set; }
        public string ConstructorId { get; set; }
        public List<int> Round { get; set; }
    }
}
