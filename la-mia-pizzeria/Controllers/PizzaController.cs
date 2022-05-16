using la_mia_pizzeria.Dati;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuovaPizzeria.Models;

namespace NuovaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List <Pizza> listaPizze = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {
                listaPizze = db.Pizze.ToList();
            }
            return View("IlMenu", listaPizze);      
        }
        [HttpGet]
        public IActionResult DettagliPizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                try
                {
                    Pizza pizzaTrovata = db.Pizze
                         .Where(post => post.Id == id)
                         .First();

                    return View("DettagliPizza", pizzaTrovata);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("La pizza con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        [HttpGet]
        public IActionResult AggiungiPizza()
        {
            return View("AggiungiPizza");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AggiungiPizza(Pizza nuovaPizza)
        {
            using(PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("AggiungiPizza", nuovaPizza);
                }
                Pizza pizzaDaAggiungere = new Pizza(nuovaPizza.UrlImmagine, nuovaPizza.Nome, nuovaPizza.Descrizione, nuovaPizza.Ingredienti, nuovaPizza.Prezzo);
                db.Pizze.Add(pizzaDaAggiungere);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        /*
        [HttpGet]
        public IActionResult ModificaPizza(int id)
        {
            Pizza pizzaDaModificare = TrovaPizzaConId(id);
            if (pizzaDaModificare != null)
            {
                return View("ModificaPizza", pizzaDaModificare);
            }
            return NotFound();
            /*Pizza pizzaDaModificare = null;
            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaModificare = db.Pizze.Where(pizza => pizza.Id == id).First();
            }

            if(pizzaDaModificare != null)
            {
                return View("ModificaPizza", pizzaDaModificare);
            }
            return NotFound();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ModificaPizza(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificaPizza", model);
            }
            Pizza pizzaDaModificare = TrovaPizzaConId(id);
            if(pizzaDaModificare != null)
            {
                pizzaDaModificare.Nome = model.Nome;
                pizzaDaModificare.UrlImmagine = model.UrlImmagine;
                pizzaDaModificare.Prezzo = model.Prezzo;
                pizzaDaModificare.Ingredienti = model.Ingredienti;
                pizzaDaModificare.Descrizione = model.Descrizione;
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EliminaPizza(int id)
        {
            int IndicePizzaDaRimuovere = -1;
            //List<Pizza> listaPizze = DatiPizze.GetPizze();
        
            for (int i = 0; i < listaPizze.Count(); i++)
            {
                if (listaPizze[i].Id == id)
                {
                    IndicePizzaDaRimuovere = i;
                }
            }
            if (IndicePizzaDaRimuovere > -1)
            {
                //DatiPizze.GetPizze().RemoveAt(IndicePizzaDaRimuovere);
                return RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }
        }




        private Pizza TrovaPizzaConId(int id)
        {
            Pizza pizzaTrovata = null;
            using(PizzaContext db = new PizzaContext())
            {
                pizzaTrovata = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                
            }
            return pizzaTrovata;
        }
        */
    }
}
