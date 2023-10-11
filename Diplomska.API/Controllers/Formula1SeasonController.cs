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

    }
}
