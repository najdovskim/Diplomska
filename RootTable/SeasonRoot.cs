using JsonToDbTest.Models;

namespace JsonToDbTest.RootTable
{
    public class SeasonRoot
    {
        public MRData MRData { get; set; }
    }

    public class SeasonTable
    {
        public List<Season> Seasons { get; set; }
    }
}
