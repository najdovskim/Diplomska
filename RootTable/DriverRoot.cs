using JsonToDbTest.Models;

namespace JsonToDbTest.RootTable
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
