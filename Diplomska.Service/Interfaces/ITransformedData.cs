using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface ITransformedData
    {
        Task<List<TransformedDataDto>> GetAllDriversData(int seasonId);
    }
}
