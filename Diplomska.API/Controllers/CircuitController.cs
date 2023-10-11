using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CircuitController : Controller
    {
        private readonly ICircuitService _circuitService;

        public CircuitController(ICircuitService circuitService)
        {
            _circuitService = circuitService;
        }


        //Circuit Get
        [HttpGet]        
        public async Task<IActionResult> GetAllCircuits(int season)
        {
            var circuits = await _circuitService.GetAllCircuits(season);
            return Ok(circuits);
        }

        [HttpGet]
        [Route("{circuitId}")]
        public async Task<IActionResult> GetCircuitById(string circuitId)
        {

            var circuit = await _circuitService.GetCircuitById(circuitId);
            if (circuit.Equals(null))
                return NotFound("Item not found");


            return Ok(circuit);
        }

    }
}
