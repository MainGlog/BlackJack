using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    //Parent class to Cat, Cow, and Dog
    public abstract class Animal //Abstract classes cannot be instantiated
    {
        public String Name { get; protected set; } = String.Empty;
        public int Age { get; protected set; }

        //public virtual void MakeSound() => Console.WriteLine("Unknown sound."); before class was abstract
        public abstract void MakeSound(); //All child classes must implement abstract members

        //Virtual allows the method to be overwritten in a child class
        //Same with abstract
        public Animal(String name, int age)
        {
            Name = name;
            Age = age;
        }

        public override String ToString()
        {
            return $"{Name} is {Age} years old";
        }

    }
}
