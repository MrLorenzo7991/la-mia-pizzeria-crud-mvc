using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Utils
{
    public static class PizzaData
    {
        private static List<Pizza> ListaPizze;

        public static List<Pizza> GetPizze()
        {
            /*List<string> ingredienti = new List<string>();
            ingredienti.Add("olio");
            ingredienti.Add("Pomodoro");
            ingredienti.Add("mozzarella");
            ingredienti.Add("Basilico");*/
            if (PizzaData.ListaPizze != null)
            {
                return PizzaData.ListaPizze;
            }
            List<Pizza> listaDiPizze = new List<Pizza>();
            for(int i = 0; i < 6; i++)  //momentaneo per vedere come va
            {
                Random random = new Random();
                int prezzoRandom = random.Next(4, 10);
                Pizza pizza = new Pizza(i, "Pizza numero " + (i+1), "Descrizione breve della pizza", prezzoRandom, "https://picsum.photos/id/"+ (i+99) +"/200/200", "olio, pomodoro, mozzarella, basilico");
                listaDiPizze.Add(pizza);
            }

            PizzaData.ListaPizze = listaDiPizze;    //qua dovevo salvare la lista pizze creata bnella variabile
            
            return listaDiPizze;
        }
    }
}
