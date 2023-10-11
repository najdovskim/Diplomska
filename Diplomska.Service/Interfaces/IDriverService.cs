using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface IDriverService
    {
        Task<List<DriverGetDto>> GetAllDrivers(int seasonId);
        Task<DriverGetDto> GetDriverById(string driverId);
    }
}
