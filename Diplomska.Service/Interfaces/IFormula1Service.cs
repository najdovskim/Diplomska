using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface IFormula1Service
    {
        Task<List<Circuit>> GetAllCircuits();
        Task<CircuitGetDto> GetCircuitById(string circuitId);

        Task<List<ConstructorGetDto>> GetAllConstructors();
        Task<ConstructorGetDto> GetConstructorById(string constructorId);

        Task<List<DriverGetDto>> GetAllDrivers();
        Task<DriverGetDto> GetDriverById(string driverId);

        Task<List<DriverStandingGetDto>> GetAllDriverStandings();
        Task<DriverStandingGetDto> GetDriverStandingById(int driverStandingId);

        Task<List<RaceGetDto>> GetAllRaces();
        Task<RaceGetDto> GetRaceById(int raceId);

        Task<List<ResultGetDto>> GetAllResults();
        Task<ResultGetDto> GetResultById(int resultId);

        Task<List<SeasonGetDto>> GetAllSeasons();
        Task<SeasonGetDto> GetSeasonById(int seasonId);
    }
}
