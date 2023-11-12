using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IConstructorRepository
    {
        Task<List<Constructor>> GetAllConstructors(int seasonId);
        Task<Constructor> GetConstructorById(string constructorId);      

    }
}
