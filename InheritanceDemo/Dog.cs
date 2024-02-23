using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    public class Dog : Animal
    {
        public bool IsTailWagging { get; private set; }

        public Dog(String name, int age, bool isTailWagging)
            : base (name, age)
        {
            IsTailWagging = isTailWagging;
        }

        public override void MakeSound() => Console.WriteLine("Bark");

        public override String ToString()
        {
            return base.ToString() + $" and {(IsTailWagging ? "is" : "is not")} wagging its tail.";
        }
    }
}
