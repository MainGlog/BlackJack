using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToStringDemo
{
    public class Person
    {
        private String name;
        private int age;
        private Color hairColor;

        public Person(string name, int age, Color hairColor)
        {
            this.name = name;
            this.age = age;
            this.hairColor = hairColor;
        }

        public override string ToString()
        {

            return $"{name} is {age} with {hairColor} hair.";
        }
    }
}
