using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Fast_Food_API.Models;

namespace Taco_Fast_Food_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();
        [HttpGet()]

        public IActionResult GetAll(string? sortByCost = null)
        {
            List<Drink> result = dbContext.Drinks.ToList();

            if (sortByCost == "ascending")
            {
                result = result.OrderBy(x => x.Cost).ToList();
                return Ok(result);
            }
            else if(sortByCost == "descending")
            {
                result = result.OrderByDescending(x => x.Cost).ToList();
                return Ok(result);
            }
            else if (sortByCost == null)
            {
                return Ok(result);
            }

            else
            {
                return NotFound("Error please Sort by ascending or descending");
            }

           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Drink result = dbContext.Drinks.FirstOrDefault(u => u.Id == id);
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
        public IActionResult AddUser([FromBody] Drink newDrink)
        {
            
            newDrink.Id = 0;
            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();

            return Created($"/api/User/{newDrink.Id}", newDrink);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Drink updatedDrink)
        {
            if (id != updatedDrink.Id) { return BadRequest("Ids don't match"); }
            if (dbContext.Drinks.Any(u => u.Id == id) == false) { return NotFound("No matching ids"); }
            dbContext.Drinks.Update(updatedDrink);
            dbContext.SaveChanges(); //DONT FORGET TO SAVE
            return Ok(updatedDrink);
        }


    }
}
