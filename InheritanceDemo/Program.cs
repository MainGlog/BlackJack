using System.Linq.Expressions;

namespace InheritanceDemo
{
    public class Program
    {
        private static List<Animal> myFarm = [];
        public static void Main(string[] args)
        {
            Cat cat = new Cat("Whiskers", 3, true); //Animal cat = ... would also work, since Cat is of type Animal
            Cow cow = new Cow("Betsy", 5, true);
            Dog dog = new Dog("Fido", 4, false);

            myFarm.Add(cat); //myFarm.Add(new Cat("Whiskers", 3, true)) would also work
            myFarm.Add(dog);
            myFarm.Add(cow);
            
            foreach(Animal a in myFarm)
            {
                Console.WriteLine(a);
                Console.WriteLine(a.GetType().Name);
                a.MakeSound();
                Console.Write(Environment.NewLine);
            }

            String bo = ".";
            string bog = "."; //Alias for String, notice aliases have blue coloration
            Int32 One = 1;
            int one = 1; //Alias for Int32

        }
    }
}
