using System.Security.Cryptography.X509Certificates;

namespace PizzaHelp
{
    public class Program
    {
        private static List<Object> cart = [];
        private static List<Pizza> pizzas = [];
        public static void Main(string[] args)
        {
            Pizza veggie = new Pizza(Pizza.PizzaType.Veggie);
            

        }
        private static void Checkout()
        {
            foreach(Object obj in cart) 
            {
                if(obj is Pizza) //obj.GetType() == typeof(Pizza)
                {
                    Pizza pizza = obj as Pizza; // casts object as pizza allowing us to use the classes things
                    //Pizza pizza = obj.Cast<Pizza>(), doesn't work with Object though

                }
            }
        }
    }
}
