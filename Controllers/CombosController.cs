using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Fast_Food_API.Models;

namespace Taco_Fast_Food_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {

        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();
        [HttpGet()]


        public IActionResult GetAll()
        {
            List<Combo> result = dbContext.Combos.ToList();
            return Ok(result);
        }

    }
}
