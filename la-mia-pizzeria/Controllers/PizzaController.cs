using la_mia_pizzeria.Dati;
using la_mia_pizzeria.Models;
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
            List<Pizza> listaPizze = new List<Pizza>();
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
                         .Where(pizza => pizza.Id == id)
                         .Include(pizza => pizza.Categoria)
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
            using (PizzaContext db = new PizzaContext()) 
            {
                List<Categoria> categorie = db.Categorie.ToList();

                PizzaCategorie model = new PizzaCategorie();
                model.Categorie = categorie;
                model.Pizza = new Pizza();
                
                return View(model);
            }

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AggiungiPizza(PizzaCategorie nuovaPizza)
        {
            using (PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    List<Categoria> categorie = db.Categorie.ToList();
                    nuovaPizza.Categorie = categorie;
                    return View("AggiungiPizza", nuovaPizza);
                }
                Pizza pizzaDaAggiungere = new Pizza();
                pizzaDaAggiungere.Nome = nuovaPizza.Pizza.Nome;
                pizzaDaAggiungere.UrlImmagine = nuovaPizza.Pizza.UrlImmagine;
                pizzaDaAggiungere.Descrizione = nuovaPizza.Pizza.Descrizione;
                pizzaDaAggiungere.Prezzo = nuovaPizza.Pizza.Prezzo;
                pizzaDaAggiungere.Ingredienti = nuovaPizza.Pizza.Ingredienti;
                pizzaDaAggiungere.CategoriaId = nuovaPizza.Pizza.CategoriaId;

                db.Pizze.Add(pizzaDaAggiungere);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int id)
        {

            Pizza? pizzaDaModificare = null;
            List<Categoria> categorie = new List<Categoria>();
            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaModificare = db.Pizze
                         .Where(post => post.Id == id)
                         .FirstOrDefault();
                categorie = db.Categorie.ToList();
            }
            if (pizzaDaModificare != null)
            {
                PizzaCategorie model = new PizzaCategorie();
                model.Pizza = pizzaDaModificare;
                model.Categorie = categorie;
                return View("ModificaPizza", model);
            }
            return NotFound();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ModificaPizza(int id, PizzaCategorie model)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificaPizza", model);
            }
            using(PizzaContext db =new PizzaContext())
            {
            Pizza? pizzaDaModificare = db.Pizze
                         .Where(post => post.Id == id)
                         .FirstOrDefault();
            if(pizzaDaModificare != null)
            {
                pizzaDaModificare.Nome = model.Pizza.Nome;
                pizzaDaModificare.UrlImmagine = model.Pizza.UrlImmagine;
                pizzaDaModificare.Prezzo = model.Pizza.Prezzo;
                pizzaDaModificare.Ingredienti = model.Pizza.Ingredienti;
                pizzaDaModificare.Descrizione = model.Pizza.Descrizione;
                pizzaDaModificare.CategoriaId = model.Pizza.CategoriaId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
            }
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EliminaPizza(int id)
        {
            using(PizzaContext db =new PizzaContext())
            {
                Pizza pizzaDaEliminare = db.Pizze.Where(post => post.Id == id).FirstOrDefault();
                if(pizzaDaEliminare != null)
                {
                    db.Pizze.Remove(pizzaDaEliminare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        
    }
}
