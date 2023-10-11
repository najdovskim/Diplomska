﻿using Diplomska.Domain.Models;
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

        Task<List<DriverStandingGetDto>> GetAllDriverStandings();
        Task<DriverStandingGetDto> GetDriverStandingById(string driverStandingId);

        Task<List<RaceGetDto>> GetAllRaces();
        Task<RaceGetDto> GetRaceById(int raceId);

        Task<List<ResultGetDto>> GetAllResults();
        Task<ResultGetDto> GetResultById(int resultId);

        Task<List<SeasonGetDto>> GetAllSeasons();
        Task<SeasonGetDto> GetSeasonById(int seasonId);
    }
}
