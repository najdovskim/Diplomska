using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransformedDataController : Controller
    {
        private readonly ITransformedData _transformedData;

        public TransformedDataController(ITransformedData transformedData)
        {
            _transformedData = transformedData;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverStandingsData(int season)
        {
            var drivers = await _transformedData.GetAllDriversData(season);
            return Ok(drivers);
        }
    }
}
