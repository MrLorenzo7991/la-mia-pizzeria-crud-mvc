using NuovaPizzeria.Models;

namespace la_mia_pizzeria.Models
{
    public class PizzaCategorie
    {
        public Pizza Pizza { get; set; }
        public List<Categoria>? Categorie { get; set; }
    }
}
