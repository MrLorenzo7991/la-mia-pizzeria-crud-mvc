using NuovaPizzeria.Valitation;
using System.ComponentModel.DataAnnotations;

namespace NuovaPizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "Devi inserire un URL")]
        public string UrlImmagine { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome deve essere di massimo 30 caratteri")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "La descrizione deve essere di massimo 100 caratteri")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [PrezzoMaggioreDi0Validation]
        public double Prezzo { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Ingredienti { get; set; }

        public Pizza()
        {

        }
        public Pizza(int Id, string UrlImmagine,string Nome, string Descrizione, string Ingredienti, double Prezzo)
        {
            this.Id = Id;
            this.UrlImmagine = UrlImmagine;
            this.Nome = Nome;
            this.Descrizione = Descrizione;
            this.Ingredienti = Ingredienti;
            this.Prezzo = Prezzo;
        }
     
    }
}
