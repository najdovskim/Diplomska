using Diplomska.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IDriverStanding
    {         
        Task<DriverStanding> GetDriverStandingByRound(int seasonId, int round);
    }
}
