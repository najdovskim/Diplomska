using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class CircuitRoot
    {
        public MRData MRData { get; set; }
    }

    public class CircuitTable
    {
        public List<Circuit> Circuits { get; set; }
    }
}
