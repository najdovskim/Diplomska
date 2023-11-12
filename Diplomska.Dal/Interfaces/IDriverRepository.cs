using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAllDrivers(int seasonId);
        Task<Driver> GetDriverById(string driverId);       
    }


}
