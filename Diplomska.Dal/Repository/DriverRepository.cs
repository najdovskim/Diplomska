using Diplomska.Dal.Interfaces;
using Diplomska.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _ctx;
        public DriverRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Driver>> GetAllDrivers(int seasonId)
        {
            return await _ctx.Drivers
            .Where(d => d.DriverStandings.Any(ds => ds.SeasonsId == seasonId))
            .ToListAsync();
        }

        public async Task<Driver> GetDriverById(string driverId)
        {
            var driver = await _ctx.Drivers.FirstOrDefaultAsync(d => d.DriverId == driverId);

            if (driver == null)
                return null;

            return driver;
        }
     
    }
}
