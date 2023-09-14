using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class DriverRoot
    {
        public MRData MRData { get; set; }
    }

    public class DriverTable
    {
        public List<Driver> Drivers { get; set; }
    }

}
