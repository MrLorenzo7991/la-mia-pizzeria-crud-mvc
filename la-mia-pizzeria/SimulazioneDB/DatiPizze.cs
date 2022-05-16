using NuovaPizzeria.Models;

namespace NuovaPizzeria.SimulazioneDB
{
    public static class DatiPizze
    {
        private static List<Pizza> listaPizze;
        
        public static List<Pizza> GetPizze()
        {
            if (DatiPizze.listaPizze != null)
            {
                return DatiPizze.listaPizze;
            }
            List<Pizza> listaDiPizze = new List<Pizza>();
            Pizza margherita = new Pizza(0, "https://staticfanpage.akamaized.net/wp-content/uploads/sites/4/2015/03/pizza-margherita-dop-napoli.jpg", "Margherita", "La più classica delle pizze", "Pomodoro, Mozzarella, Olio, Basilico", 4.00);
            Pizza marinara = new Pizza(1, "https://primochef.it/wp-content/uploads/2018/05/SH_pizza_alla_marinara.jpg", "Marinara", "Tanto semplice quanto buona", "Pomodoro, Origano, Aglio, Olio", 3.50);
            Pizza pub = new Pizza(2, "https://www.scattidigusto.it/wp-content/uploads/2015/11/pizza-wurstel-e-patatine.jpg", "Pub", "La pizza più amata dai bambini", "Mozzarella, Patatine, Wrustel, Olio", 5.00);
            Pizza diavola = new Pizza(3, "https://i.ytimg.com/vi/S1__vdNiuGQ/maxresdefault.jpg", "Diavola", "Per gli amanti del piccante", "Pomodoro, Mozzarella, Salame piccante, Olio", 5.00);
            Pizza crocche = new Pizza(4, "https://www.napolitan.it/wp-content/uploads/2016/08/13879232_1285048341507681_3851322985978680965_n.jpg", "Crocchè", "Crocchè su di una pizza? Cosa c'è di meglio?", "Panna, Mozzarella, Crocchè, Prosciutto Cotto, Olio", 7.00);
            Pizza mimosa = new Pizza(5, "https://media-cdn.tripadvisor.com/media/photo-p/19/fc/70/af/pizza-mimosa-panna-mozzarella.jpg", "Mimosa", "Una pizza bella come un fiore", "Panna, Mais, Prosciutto Cotto, Mozzarella, olio", 6.00);
            listaDiPizze.Add(margherita);
            listaDiPizze.Add(marinara);
            listaDiPizze.Add(pub);
            listaDiPizze.Add(diavola);
            listaDiPizze.Add(crocche);
            listaDiPizze.Add(mimosa);

            DatiPizze.listaPizze = listaDiPizze;
            return listaDiPizze;
        }
    }
}
