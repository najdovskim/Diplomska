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
     
     
        public async Task<List<Result>> GetAllResults()
        {
            return await _ctx.Results.ToListAsync();
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
