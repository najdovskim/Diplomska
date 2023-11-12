using Diplomska.Dal.Interfaces;
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
        private readonly IDriverStandingRepository _driverStandingRepository;

        public DriverStandingController(IDriverStandingService driverStandingService, IDriverStandingRepository driverStandingRepository)
        {
            _driverStandingService = driverStandingService;
            _driverStandingRepository = driverStandingRepository;
        }

        [HttpGet]
        [EnableCors("corsapp")]
        public async Task<IActionResult> GetAllDriverStandingByRound(int season, int round)
        {
            var driverStandings = await _driverStandingService.GetDriverStandingByRound(season, round);

            return Ok(driverStandings);
        }
        /* [HttpGet]
         [EnableCors("corsapp")]
         [Route("{season}")]
         public async Task<IActionResult> GetAllDriverStandings(int season)
         {
             var driverStandings = await _driverStandingService.GetAllDriverStandings(season);

             return Ok(driverStandings);
         }*/
        
        [HttpGet]
        [EnableCors("corsapp")]
        [Route("{driverId}")]
        public async Task<IActionResult> GetByDriver(string driver)
        {
            var driverStandings = await _driverStandingRepository.GetStandingsForDriver(driver);            

            return Ok(driverStandings);
                }

      /*  [HttpGet]
        [EnableCors("corsapp")]
        [Route("{constructor}")]
        public async Task<IActionResult> GetByConstructor(string constructor)
        {
            var driverStandings = await _driverStandingRepository.GetStandingsForConstructor(constructor);

            return Ok(driverStandings);
        }*/

    }
}
