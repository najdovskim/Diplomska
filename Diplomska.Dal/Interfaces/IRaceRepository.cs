using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IRaceRepository
    {
        Task<List<Race>> GetAllRaces(int seasonId);
        Task<Race> GetRaceById(int raceId);
    }
}
