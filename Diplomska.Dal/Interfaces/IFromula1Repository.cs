﻿using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IFromula1Repository
    {
        Task<List<Circuit>> GetAllCircuits();
        Task<Circuit> GetCircuitById(string circuitId);

        Task<List<Constructor>> GetAllConstructors();
        Task<Constructor> GetConstructorById(string constructorId);

        Task<List<Driver>> GetAllDrivers();
        Task<Driver> GetDriverById(string driverId);

        Task<List<DriverStanding>> GetAllDriverStandings();
        Task<DriverStanding> GetDriverStandingById(int driverStandingId);

        Task<List<Race>> GetAllRaces();
        Task<Race> GetRaceById(int raceId);

        Task<List<Result>> GetAllResults();
        Task<Result> GetResultById(int resultId);

        Task<List<Season>> GetAllSeasons();
        Task<Season> GetSeasonById(int seasonId);

    }
}
