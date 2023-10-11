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
    public class Fromula1Repository : IFromula1Repository
    {

        private readonly DataContext _ctx;
        public Fromula1Repository(DataContext ctx)
        {
            _ctx = ctx;
        }

     
        public async Task<List<DriverStanding>> GetAllDriverStandings()
        {
            return await _ctx.DriverStandings.ToListAsync();
        }

        public async Task<List<Race>> GetAllRaces()
        {
            return await _ctx.Races.ToListAsync();
        }

        public async Task<List<Result>> GetAllResults()
        {
            return await _ctx.Results.ToListAsync();
        }
            

        public async Task<DriverStanding> GetDriverStandingById(string driverStandingId)
        {
            var driverStanding = await _ctx.DriverStandings.FirstOrDefaultAsync(c => c.Position == driverStandingId);

            if (driverStanding == null)
                return null;

            return driverStanding;
        }

        public async Task<Race> GetRaceById(int raceId)
        {
            var race = await _ctx.Races.FirstOrDefaultAsync(r => r.RaceId == raceId);

            if (race == null)
                return null;

            return race;
        }

        public async Task<Result> GetResultById(int resultId)
        {
            var result = await _ctx.Results.FirstOrDefaultAsync(r => r.numberId == resultId);

            if (result == null)
                return null;

            return result;    
        }
      
    }
}
