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
    public class SeasonRepository: ISeasonRepository
    {
        private readonly DataContext _ctx;
        public SeasonRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            return await _ctx.Seasons.ToListAsync();
        }

        public async Task<Season> GetSeasonById(int seasonId)
        {
            var season = await _ctx.Seasons.FirstOrDefaultAsync(c => c.SeasonId == seasonId);

            if (season == null)
                return null;

            return season;
        }

    }
}
