using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
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
