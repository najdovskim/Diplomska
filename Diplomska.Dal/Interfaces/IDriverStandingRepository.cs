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
        //Task<List<DriverStanding>> GetAllDriverStandingsByDriver(int seasonId, string driver);
        Task<List<DriverStanding>> GetAllDriverStandings(int seasonId);
        Task<TransformedData> GetStandingsForDriver(string driverId);
        Task<List<DriverStanding>> GetStandingsForConstructor(string constructorId);

    }
}
