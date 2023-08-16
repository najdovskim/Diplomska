using JsonToDbTest.Models;

namespace JsonToDbTest.RootTable
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
