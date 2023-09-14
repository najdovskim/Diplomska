using AutoMapper;
using Diplomska.Dal.Interfaces;
using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using Diplomska.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Services
{
    public class Formula1Service : IFormula1Service
    {
        private readonly IFromula1Repository _fromula1Repository;
        private readonly IMapper _mapper;

        public Formula1Service(IFromula1Repository fromula1Repo, IMapper mapper)
        {            
            _mapper = mapper;
            _fromula1Repository = fromula1Repo;
        }


        public async Task<List<CircuitGetDto>> GetAllCircuits()
        {
            var circuits = await _fromula1Repository.GetAllCircuits();
            var circuitsGet = _mapper.Map<List<CircuitGetDto>>(circuits);

            return circuitsGet;
        }

        public async Task<List<ConstructorGetDto>> GetAllConstructors()
        {
            var constructors = await _fromula1Repository.GetAllConstructors();
            var constructorsGet = _mapper.Map<List<ConstructorGetDto>>(constructors);

            return constructorsGet;
        }

        public async Task<List<DriverGetDto>> GetAllDrivers()
        {
            var drivers = await _fromula1Repository.GetAllDrivers();
            var driversGet = _mapper.Map<List<DriverGetDto>>(drivers);

            return driversGet; 
        }

        public async Task<List<DriverStandingGetDto>> GetAllDriverStandings()
        {
            var driverStandings = await _fromula1Repository.GetAllDriverStandings();
            var driverStandingGet = _mapper.Map<List<DriverStandingGetDto>>(driverStandings);

            return driverStandingGet;
        }

        public async Task<List<RaceGetDto>> GetAllRaces()
        {
            var races = await _fromula1Repository.GetAllRaces();
            var racesGet = _mapper.Map<List<RaceGetDto>>(races);

            return racesGet;
        }

        public async Task<List<ResultGetDto>> GetAllResults()
        {
            var results = await _fromula1Repository.GetAllResults();
            var resultGet = _mapper.Map<List<ResultGetDto>>(results);

            return resultGet;
        }

        public async Task<List<SeasonGetDto>> GetAllSeasons()
        {
            var seasons = await _fromula1Repository.GetAllSeasons();
            var seasonsGet = _mapper.Map<List<SeasonGetDto>>(seasons);

            return seasonsGet;
        }

        public async Task<CircuitGetDto> GetCircuitById(string circuitId)
        {
            var circuit = await _fromula1Repository.GetCircuitById(circuitId);

            if (circuitId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<CircuitGetDto>(circuit);
            return mapped;
        }

        public async Task<ConstructorGetDto> GetConstructorById(string constructorId)
        {
            var constructor = await _fromula1Repository.GetConstructorById(constructorId);

            if (constructorId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<ConstructorGetDto>(constructor);
            return mapped;
        }

        public async Task<DriverGetDto> GetDriverById(string driverId)
        {
            var driver = await _fromula1Repository.GetDriverById(driverId);


            if (driverId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<DriverGetDto>(driver);
            return mapped;
        }

        public async Task<DriverStandingGetDto> GetDriverStandingById(int driverStandingId)
        {
            var driverStanding = await _fromula1Repository.GetDriverStandingById(driverStandingId);


            if (driverStandingId == null )
            {
                return null;
            }

            var mapped = _mapper.Map<DriverStandingGetDto>(driverStanding);
            return mapped;
        }

        public async Task<RaceGetDto> GetRaceById(int raceId)
        {
            var race = await _fromula1Repository.GetRaceById(raceId);


            if (race == null)
            {
                return null;
            }

            var mapped = _mapper.Map<RaceGetDto>(race);
            return mapped;
        }

        public async Task<ResultGetDto> GetResultById(int resultId)
        {
            var result = await _fromula1Repository.GetResultById(resultId);


            if (result == null)
            {
                return null;
            }

            var mapped = _mapper.Map<ResultGetDto>(result);
            return mapped;
        }

        public async Task<SeasonGetDto> GetSeasonById(int seasonId)
        {
            var season = await _fromula1Repository.GetSeasonById(seasonId);


            if (season == null)
            {
                return null;
            }

            var mapped = _mapper.Map<SeasonGetDto>(season);
            return mapped;
        }
    }
}
