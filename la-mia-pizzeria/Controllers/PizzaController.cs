using la_mia_pizzeria.Models;
using la_mia_pizzeria.Utils;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizzaList = PizzaData.GetPizze();
            return View("LeNostrePizze", pizzaList);
        }
        [HttpGet]
        public IActionResult DettaglioPizza(int id)
        {
            Pizza pizzaTrovata = TrovaPizzaConId(id);

            if (pizzaTrovata == null)
            {
                return View("Error");
            }
            return View(pizzaTrovata);
        }
        [HttpGet]
        public IActionResult AggiungiPizza()
        {
            return View("AggiungiPizza");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AggiungiPizza(Pizza nuovaPizza)    //qua forse vuole gli ingredienti direttamente in lista
        {
            if (!ModelState.IsValid)
            {
                return View("AggiungiPizza", nuovaPizza);
            }
            //gli ingredienti sono inseriti in stringa separati da ;
            /*List<string> ingredienti = new List<string>();
            string[] ingredientiStringa = nuovaPizza.Ingredienti.ToString().Split(';');
            foreach (string ingrediente in ingredientiStringa)
            {
                ingredienti.Add(ingrediente);
            }*/

            Pizza pizzaDaAggiungere = new Pizza(PizzaData.GetPizze().Count, nuovaPizza.Name, nuovaPizza.Description, nuovaPizza.prezzo, nuovaPizza.image, nuovaPizza.Ingredienti);
            PizzaData.GetPizze().Add(pizzaDaAggiungere);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int id)
        {
            Pizza pizzaDaModificare = TrovaPizzaConId(id);
            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("ModificaPizza", pizzaDaModificare);
            }
            
        }
        [HttpPost]
        public IActionResult ModificaPizza(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificaPizza", model);
            }

            Pizza pizzaDaModificare = TrovaPizzaConId(id);

            if(pizzaDaModificare != null)
            {
                pizzaDaModificare.Name = model.Name;
                pizzaDaModificare.Description = model.Description;
                pizzaDaModificare.prezzo = model.prezzo;
                pizzaDaModificare.Ingredienti=model.Ingredienti;
                pizzaDaModificare.image = model.image;
                return RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult EliminaPizza(int id)
        {
            int IndicePizzaDaRimuovere = -1;
            List<Pizza> listaPizze = PizzaData.GetPizze();
            foreach(Pizza pizza in listaPizze)
            {
                if (pizza.Id == id)
                {
                    IndicePizzaDaRimuovere = id;
                }
            }
            if (IndicePizzaDaRimuovere > -1)
            {
                PizzaData.GetPizze().RemoveAt(IndicePizzaDaRimuovere);
                return RedirectToAction("index");
            }
            else
            {
                return NotFound();
            }

        }
        
        
        
        
        
        
        //metodo//
        private Pizza TrovaPizzaConId(int id)
        {
            Pizza pizzaTrovata = null;
            foreach (Pizza pizza in PizzaData.GetPizze())
            {
                if (pizza.Id == id)
                {
                    pizzaTrovata = pizza;
                    break;
                }
            }
            return pizzaTrovata;
        }
    }
}
