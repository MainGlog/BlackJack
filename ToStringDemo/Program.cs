using System.Drawing;

namespace ToStringDemo
{
    public class Program
    {
        private static List<Object> items = [];
        public static void Main()
        {
            items.Add(new Person("Nicholas", 27, Color.Brown));
            items.Add(new Person("John", 20, Color.Purple));
            items.Add(new Rock("Granite", "Igneous", 15.5));
            items.Add(new Rock("Sandstone", "Sedimentary", 12.2));
            PrintMyItems();
        }

        public static void PrintMyItems()
        {
            foreach(Object item in items) 
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
