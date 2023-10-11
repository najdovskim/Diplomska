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
    public class DriverStandingRepository : IDriverStandingRepository
    {
        public readonly DataContext _ctx;

        public DriverStandingRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<DriverStanding>> GetDriverStandingByRound(int seasonId, int round)
        {

            var driverStanding = await _ctx.DriverStandings.Where(d => d.SeasonsId == seasonId && d.Round == round).ToListAsync();
           

            if (driverStanding == null)
                return null;

            return driverStanding;
        }
       
    }
}
