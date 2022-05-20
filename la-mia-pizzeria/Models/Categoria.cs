using NuovaPizzeria.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace la_mia_pizzeria.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Il nome della categoria non può superare i 50 caratteri")]
        public string Nome { get; set; }
        
        [JsonIgnore]
        public List<Pizza> Pizze { get; set; }

        public Categoria()
        {

        }
    }
}
