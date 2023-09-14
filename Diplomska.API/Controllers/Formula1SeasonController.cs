using Diplomska.Service.Interfaces;
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


        [HttpGet]
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
    }
}
