using la_mia_pizzeria.Dati;
using Microsoft.AspNetCore.Mvc;
using NuovaPizzeria.Models;

namespace la_mia_pizzeria.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Pizza> pizze = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {
                pizze = db.Pizze.ToList<Pizza>();
            }
            return Ok(pizze);
        }
    }
}
