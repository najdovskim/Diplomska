using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Formula1SeasonController : Controller
    {
        private readonly IFormula1Service _formula1Service;
        
        public Formula1SeasonController( IFormula1Service formula1Service)
        {
            _formula1Service = formula1Service;
        }

        //Circuit Get
        [HttpGet]
        [Route("{circuit}")]
        public async Task<IActionResult> GetAllCircuits()
        {
            var circuits = await _formula1Service.GetAllCircuits();
            return Ok(circuits);
        }

        [HttpGet]
        [Route("{circuitId}")]
        public async Task<IActionResult> GetCircuitById(string circuitId)
        {

            var circuit = await _formula1Service.GetCircuitById(circuitId);
            if (circuit.Equals(null))
                return NotFound("Item not found");
            

            return Ok(circuit);
        }

        //Constructor Get

        [HttpGet]
        [Route("{constructor}")]
        public async Task<IActionResult> GetAllConstructor()
        {
            var constructors = await _formula1Service.GetAllConstructors();
            return Ok(constructors);
        }

        [HttpGet]
        [Route("{constructorId}")]
        public async Task<IActionResult> GetConstructorById(string constructorId)
        {

            var constructor = await _formula1Service.GetConstructorById(constructorId);
            if (constructor.Equals(null))
                return NotFound("Item not found");


            return Ok(constructor);
        }

      


        //DriverStanding Get
        [HttpGet]
        [Route("{driverStanding}")]
        public async Task<IActionResult> GetAllDriverStanding()
        {
            var driverStandings = await _formula1Service.GetAllDriverStandings();
            return Ok(driverStandings);
        }

        [HttpGet]
        [Route("{driverStandingId}")]
        public async Task<IActionResult> GetDriverStandingById(string driverStandingId)
        {
            var driverStanding = await _formula1Service.GetDriverStandingById(driverStandingId);
            if (driverStanding.Equals(null))
                return NotFound("Item not found");

            return Ok(driverStanding);
        }


        //Race Get
        [HttpGet]
        [Route("{race}")]
        public async Task<IActionResult> GetAllRaceStanding()
        {
            var races = await _formula1Service.GetAllRaces();
            return Ok(races);
        }

        [HttpGet]
        [Route("{raceId}")]
        public async Task<IActionResult> GetRaceById(int raceId)
        {
            var race = await _formula1Service.GetRaceById(raceId);
            if (race.Equals(null))
                return NotFound("Item not found");

            return Ok(race);
        }

        //Result Get
        [HttpGet]
        [Route("{result}")]
        public async Task<IActionResult> GetAllResultStanding()
        {
            var results = await _formula1Service.GetAllResults();
            return Ok(results);
        }

        [HttpGet]
        [Route("{resultId}")]
        public async Task<IActionResult> GetResultById(int resultId)
        {
            var result = await _formula1Service.GetResultById(resultId);
            if (result.Equals(null))
                return NotFound("Item not found");

            return Ok(result);
        }


        //Season Get
        [HttpGet]
        [Route("{season}")]
        public async Task<IActionResult> GetAllSeasonStanding()
        {
            var seasons = await _formula1Service.GetAllSeasons();
            return Ok(seasons);
        }

        [HttpGet]
        [Route("{seasonId}")]
        public async Task<IActionResult> GetSeasonById(int seasonId)
        {
            var season = await _formula1Service.GetSeasonById(seasonId);
            if (season.Equals(null))
                return NotFound("Item not found");

            return Ok(season);
        }


    }
}
