using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface IRaceService
    {
        Task<List<RaceGetDto>> GetAllRaces(int seasonId);
        Task<RaceGetDto> GetRaceById(int raceId);
    }
}
