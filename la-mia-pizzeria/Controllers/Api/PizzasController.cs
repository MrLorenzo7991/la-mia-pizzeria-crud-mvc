using la_mia_pizzeria.Dati;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuovaPizzeria.Models;

namespace la_mia_pizzeria.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? searchString)
        {
            List<Pizza> pizze = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {
                if (searchString != null)
                {
                    pizze = db.Pizze.Where(pizza => pizza.Nome.Contains(searchString) || pizza.Ingredienti.Contains(searchString)).ToList();
                }
                else
                {
                    pizze = db.Pizze.Include(pizza => pizza.Categoria).ToList<Pizza>();
                }
            }
            return Ok(pizze);
        }
    }
}
