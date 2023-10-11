using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }


        //Driver Get
        [HttpGet]        
        [EnableCors("corsapp")]
        public async Task<IActionResult> GetAllDriver(int season)
        {
            var drivers = await _driverService.GetAllDrivers(season);
            return Ok(drivers);
        }

        [HttpGet]
        [Route("{driverId}")]
        public async Task<IActionResult> GetDriverById(string driverId)
        {
            var driver = await _driverService.GetDriverById(driverId);
            if (driver.Equals(null))
                return NotFound("Item not found");

            return Ok(driver);
        }
    }
}
