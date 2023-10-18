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
    public class CircuitRepository : ICircuitRepository
    {
        private readonly DataContext _ctx;
        public CircuitRepository(DataContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<List<Circuit>> GetAllCircuits(int seasonId)
        {
            return await _ctx.Circuits
           .Where(c => c.Races.Any(r => r.SeasonId == seasonId))
           .ToListAsync();
        }

        public async Task<Circuit> GetCircuitById(string circuitId)
        {
            var circuit = await _ctx.Circuits.FirstOrDefaultAsync(c => c.CircuitId == circuitId);

            if (circuit == null)
                return null;

            return circuit;
        }
    }
}
