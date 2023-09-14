using Diplomska.Domain.Models;

namespace Diplomska.Dal.RootTable
{
    public class ConstructorRoot
    {
        public MRData MRData { get; set; }
    }


    public class ConstructorTable
    {
        public List<Constructor> Constructors { get; set; }
    }
}
