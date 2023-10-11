using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        //Race Get
        [HttpGet]  
        public async Task<IActionResult> GetAllRaceStanding(int season)
        {
            var races = await _raceService.GetAllRaces(season);
            return Ok(races);
        }

        [HttpGet]
        [Route("{raceId}")]
        public async Task<IActionResult> GetRaceById(int raceId)
        {
            var race = await _raceService.GetRaceById(raceId);
            if (race.Equals(null))
                return NotFound("Item not found");

            return Ok(race);
        }
    }
}
