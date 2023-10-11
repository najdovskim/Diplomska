using Diplomska.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConstructorController : Controller
    {
        private readonly IConstructorService _constructorService;

        public ConstructorController(IConstructorService constructorService)
        {
            _constructorService = constructorService;
        }



        //Constructor Get
        [HttpGet]        
        public async Task<IActionResult> GetAllConstructor(int season)
        {
            var constructors = await _constructorService.GetAllConstructors(season);
            return Ok(constructors);
        }

        [HttpGet]
        [Route("{constructorId}")]
        public async Task<IActionResult> GetConstructorById(string constructorId)
        {

            var constructor = await _constructorService.GetConstructorById(constructorId);
            if (constructor.Equals(null))
                return NotFound("Item not found");


            return Ok(constructor);
        }

    }
}
