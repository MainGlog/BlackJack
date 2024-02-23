using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHelp
{
    public class Pizza
    {
        public record Size(String Name, float Price, float ToppingPrice); //Special type of class, no body
        //allows us to use the tuple without writing all three
        //use this if 3+ types in tuple
        public static readonly List<Size> sizes =
          [
             new Size("Small", 5.99f, 0.5f),
             new Size("Medium", 7.99f, 0.7f)
          ]; 
        public enum PizzaType
        {
            Regular,
            Veggie
        }
        private PizzaType type;
        
        private List<(String name, bool veggie)> Toppings = []; //used when creating pizza
        private Size size;
        //Don't use enums for toppings
        private static readonly (String name, bool veggie)[] toppings =
        {
            ("Pepperoni", false),
            ("Bacon", false),
            ("Sausage", false),
            ("Pineapple", true),
            ("Mushrooms", true),
            ("Peppers", true)
        };
        public Pizza(PizzaType type)
        {
            this.type = type;
            size = sizes[0];
            Console.WriteLine(size.Price);
            Console.WriteLine(size.ToppingPrice);
            Console.WriteLine(size.Name);
        }
        public Pizza() : this(PizzaType.Regular) 
        { 
        }
         // public Pizza() => type = PizzaType.Regular;
        

        
   

    }
}
