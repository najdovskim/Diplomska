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

        
        public async Task<List<Circuit>> GetAllCircuits()
        {
            return await _ctx.Circuits.ToListAsync();
        }
        

        public async Task<List<Constructor>> GetAllConstructors()
        {
            return await _ctx.Constructors.ToListAsync();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _ctx.Drivers.ToListAsync();
        }

        public async Task<List<DriverStanding>> GetAllDriverStandings()
        {
            return await _ctx.DriverStandings.ToListAsync();
        }

        public async Task<List<Race>> GetAllRaces()
        {
            return await _ctx.Races.ToListAsync();
        }

        public async Task<List<Result>> GetAllResults()
        {
            return await _ctx.Results.ToListAsync();
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            return await _ctx.Seasons.ToListAsync();
        }

        public async Task<Circuit> GetCircuitById(string circuitId)
        {
            var circuit = await _ctx.Circuits.FirstOrDefaultAsync(c => c.CircuitId == circuitId);

            if (circuit == null)
                return null;

            return circuit;
        }

        public async Task<Constructor> GetConstructorById(string constructorId)
        {
            var constructor = await _ctx.Constructors.FirstOrDefaultAsync(c => c.ConstructorId == constructorId);

            if (constructor == null)
                return null;

            return constructor;
        }

        public async Task<Driver> GetDriverById(string driverId)
        {
            var driver = await _ctx.Drivers.FirstOrDefaultAsync(d => d.DriverId == driverId);

            if (driver == null)
                return null;

            return driver;
        }

        public async Task<DriverStanding> GetDriverStandingById(int driverStandingId)
        {
            var driverStanding = await _ctx.DriverStandings.FirstOrDefaultAsync(c => c.Position == driverStandingId);

            if (driverStanding == null)
                return null;

            return driverStanding;
        }

        public async Task<Race> GetRaceById(int raceId)
        {
            var race = await _ctx.Races.FirstOrDefaultAsync(r => r.RaceId == raceId);

            if (race == null)
                return null;

            return race;
        }

        public async Task<Result> GetResultById(int resultId)
        {
            var result = await _ctx.Results.FirstOrDefaultAsync(r => r.numberId == resultId);

            if (result == null)
                return null;

            return result;
        }

        public async Task<Season> GetSeasonById(int seasonId)
        {
            var season = await _ctx.Seasons.FirstOrDefaultAsync(c => c.SeasonId == seasonId);

            if (season == null)
                return null;

            return season;
        }
    }
}
