using la_mia_pizzeria.Dati;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using NuovaPizzeria.Models;

namespace la_mia_pizzeria.Controllers
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {       
        [HttpPost]
        public IActionResult AggiungiPizza([FromBody] Favourites data)
        {
            int id = data.IdPizza;
            PizzePreferite.idPizzePreferite.Add(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Pizza> pizzaPreferite = new List<Pizza>();
            
            for(int i = 0; i < PizzePreferite.idPizzePreferite.Count(); i++)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    Pizza pizzaDaAgggiungere = db.Pizze
                             .Where(pizza => pizza.Id == PizzePreferite.idPizzePreferite[i])
                             .FirstOrDefault();
                    pizzaPreferite.Add(pizzaDaAgggiungere);
                }
            }
            return Ok(pizzaPreferite);
        }
    }
}
