using Diplomska.Dal.Repository;
using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IDriverStandingRepository
    {         
        Task<List<DriverStanding>> GetDriverStandingByRound(int seasonId, int round);
    }
}
