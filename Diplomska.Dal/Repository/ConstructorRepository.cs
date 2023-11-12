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
    public class ConstructorRepository : IConstructorRepository
    {
        private readonly DataContext _ctx;
        public ConstructorRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Constructor>> GetAllConstructors(int seasonId)
        {         
            return await _ctx.Constructors
            .Where(c => c.DriverStandings.Any(ds => ds.SeasonsId == seasonId))
            .ToListAsync();
        }

        public async Task<Constructor> GetConstructorById(string constructorId)
        {
            var constructor = await _ctx.Constructors.FirstOrDefaultAsync(c => c.ConstructorId == constructorId);

            if (constructor == null)
                return null;

            return constructor;
        }
  
    }
}
