using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using Taco_Fast_Food_API.Models;

namespace Taco_Fast_Food_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();
        [HttpGet()]


        public IActionResult GetAll(bool? soft = null)
        {
            List<Taco> result = dbContext.Tacos.ToList();

            if (soft != null)
            {
                result = result.Where(x => x.SoftShell == soft).ToList();
            }

            return Ok(result);
        }


        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Taco result = dbContext.Tacos.FirstOrDefault(u => u.Id == id);
            if (result == null)
            {
                return NotFound("No matching Id");
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost()]
        public IActionResult AddUser([FromBody] Taco newItem)
        {
            //prevent error with incrementing
            newItem.Id = 0;
            dbContext.Tacos.Add(newItem);
            dbContext.SaveChanges();

            return Created($"/api/User/{newItem.Id}", newItem);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            Taco u = dbContext.Tacos.FirstOrDefault(x => x.Id == id);
            if (u == null)
            {
                return NotFound("No matching id");
            }
            else
            {
                dbContext.Tacos.Remove(u);
                dbContext.SaveChanges();
                return NoContent();

                //deleting all tickets
                //prevent table relation errors
                List<Taco> matchingItems = dbContext.Tacos.Where(t => t.Id == u.Id).ToList();
                dbContext.Tacos.RemoveRange(matchingItems);
            }
        }




    }
}
