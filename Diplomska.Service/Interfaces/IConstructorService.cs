using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface IConstructorService
    {
        Task<List<ConstructorGetDto>> GetAllConstructors(int seasonId);
        Task<ConstructorGetDto> GetConstructorById(string constructorId);
    }
}
