using Microsoft.AspNetCore.Mvc;
using NuovaPizzeria.Models;
using NuovaPizzeria.SimulazioneDB;

namespace NuovaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> listaPizze = DatiPizze.GetPizze();
            return View("IlMenu", listaPizze);      //devo inserire il database(Per ora lo simulo)
        }
        [HttpGet]
        public IActionResult DettagliPizza(int id)
        {
            Pizza pizzaTrovata = new Pizza();
            foreach(Pizza pizza in DatiPizze.GetPizze())
            {
                if (id == pizza.Id)
                {
                    pizzaTrovata = pizza;
                }
            }
            return View("DettagliPizza", pizzaTrovata);
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
            if (!ModelState.IsValid)
            {
                return View("AggiungiPizza", nuovaPizza);
            }
            Pizza pizzaDaAggiungere = new Pizza(DatiPizze.GetPizze().Count, nuovaPizza.UrlImmagine, nuovaPizza.Nome, nuovaPizza.Descrizione, nuovaPizza.Ingredienti, nuovaPizza.Prezzo);
            DatiPizze.GetPizze().Add(pizzaDaAggiungere);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ModificaPizza(int id)
        {
            Pizza pizzaDaModificare = TrovaPizzaConId(id);
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
            List<Pizza> listaPizze = DatiPizze.GetPizze();
            
            for (int i = 0; i < listaPizze.Count(); i++)
            {
                if (listaPizze[i].Id == id)
                {
                    IndicePizzaDaRimuovere = i;
                }
            }
            if (IndicePizzaDaRimuovere > -1)
            {
                DatiPizze.GetPizze().RemoveAt(IndicePizzaDaRimuovere);
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
            foreach (Pizza pizza in DatiPizze.GetPizze())
            {
                if (pizza.Id == id)
                {
                    pizzaTrovata = pizza;
                }
            }
            return pizzaTrovata;
        }
            

    }
}
