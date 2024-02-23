using System.Threading.Channels;

namespace InheritanceDemo
{
    public class Cat : Animal //Classes can only inherent one class
    {
        public bool IsPurring { get; private set; }
        public Cat(String name, int age, bool isPurring) 
            : base (name, age) 
        //Child classes must construct its parent class
        //Cat, Animal, Object
        {
            IsPurring = isPurring;
        }
        public override void MakeSound() => Console.WriteLine("Meow");

    }
}
