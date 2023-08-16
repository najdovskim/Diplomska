namespace JsonToDbTest.RootTable
{
    public class MRData
    {
        public string Xmlns { get; set; }
        public string Series { get; set; }
        public string Url { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
        public string Total { get; set; }
        public ConstructorTable ConstructorTable { get; set; }
        public DriverTable DriverTable { get; set; }
        public CircuitTable CircuitTable { get; set; }
        public RaceTable RaceTable { get; set; }
        public SeasonTable SeasonTable { get; set; } 
    }
}
