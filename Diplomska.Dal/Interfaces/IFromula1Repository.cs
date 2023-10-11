using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IFromula1Repository
    {    
        Task<List<DriverStanding>> GetAllDriverStandings();
        Task<DriverStanding> GetDriverStandingById(string driverStandingId);

        Task<List<Race>> GetAllRaces();
        Task<Race> GetRaceById(int raceId);

        Task<List<Result>> GetAllResults();
        Task<Result> GetResultById(int resultId);

        Task<List<Season>> GetAllSeasons();
        Task<Season> GetSeasonById(int seasonId);

    }
}
