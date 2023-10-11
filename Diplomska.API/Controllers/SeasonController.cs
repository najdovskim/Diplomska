using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        //Season Get
        [HttpGet]        
        public async Task<IActionResult> GetAllSeasonStanding()
        {
            var seasons = await _seasonService.GetAllSeasons();
            return Ok(seasons);
        }

        [HttpGet]
        [Route("{seasonId}")]
        public async Task<IActionResult> GetSeasonById(int seasonId)
        {
            var season = await _seasonService.GetSeasonById(seasonId);
            if (season.Equals(null))
                return NotFound("Item not found");

            return Ok(season);
        }
    }
}
