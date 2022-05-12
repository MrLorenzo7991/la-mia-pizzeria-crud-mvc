using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage ="Il nome deve essere di massimo 50 caratteri")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome deve essere di massimo 100 caratteri")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "Il campo deve essere un Url di un immagine")]
        public string image { get; set; }
        [Required(ErrorMessage ="Il campo è obbligatorio")]
        public int prezzo { get; set; }                   
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Ingredienti { get; set; } 

        public Pizza()
        {

        }

        public Pizza(int id, string name, string desctiption,int prezzo , string image , string ingredienti)
        {
            this.Id=id;
            this.Name=name;
            this.Description=desctiption;
            this.prezzo=prezzo;
            this.image=image;
            this.Ingredienti = ingredienti;
        }
    }
}
