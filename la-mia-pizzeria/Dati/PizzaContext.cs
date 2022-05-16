using Microsoft.EntityFrameworkCore;
using NuovaPizzeria.Models;

namespace la_mia_pizzeria.Dati
{
    public class PizzaContext :DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaLorenzoMiccio;Integrated Security=True");
        }
    }
}
