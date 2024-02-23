using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Student
    {
        private String name;
        private int age;

        public Student() { }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public String GetName() => name;
        public void SetName(String name) => this.name = name;
        public int GetAge() => age; //Return implied, only one instruction can go here and it has to return something/
        public void SetAge(int age) => this.age = age;
        
        

    }
}
