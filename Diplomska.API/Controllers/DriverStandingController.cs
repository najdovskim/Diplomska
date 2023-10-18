using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverStandingController : Controller
    {
        private readonly IDriverStandingService _driverStandingService;

        public DriverStandingController(IDriverStandingService driverStandingService)
        {
            _driverStandingService = driverStandingService;
        }

        [HttpGet]
        [EnableCors("corsapp")]
        public async Task<IActionResult> GetAllDriverStandingByRound(int season, int round)
        {
            var driverStandings = await _driverStandingService.GetDriverStandingByRound(season, round);

            return Ok(driverStandings);
        }
    }
}
