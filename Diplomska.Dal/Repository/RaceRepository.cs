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
    public class RaceRepository : IRaceRepository
    {
        private readonly DataContext _ctx;
        public RaceRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Race>> GetAllRaces(int seasonId)
        {
            return await _ctx.Races
                .Where(r => r.SeasonId == seasonId)
                .ToListAsync();
        }

        public async Task<Race> GetRaceById(int raceId)
        {
            var race = await _ctx.Races.FirstOrDefaultAsync(r => r.RaceId == raceId);

            if (race == null)
                return null;

            return race;
        }
    }
}
