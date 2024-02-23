using System.Net.Sockets;
using System.Runtime.Versioning;

namespace ClassDemo
{
    public class Fruit
    {
        public String name;
    }
    public class Program
    {
        public static void Main()
        {
            Fruit apple = new Fruit { name = "Florida Orange" };
            Fruit orange = new Fruit { name = "Red Delicious" };

            String temp = apple.name;
            apple.name = orange.name;
            orange.name = temp;

            Student bob = new Student(); //"new" keyword before any object, instructs the program to build a new object from the blueprint during runtime
            bob.fname = "Bob";
            bob.lname = "Bobson";
            bob.address = "123 Main St";
            bob.birthDate = new DateOnly(1970, 2, 1);
            bob.tuitionPaid = true;
            Console.WriteLine(bob.GetFullName());
            Console.WriteLine(bob.GetAge());

            Student logan = new Student()
            {
                fname = "Logan",
                lname = "Brooks",
                birthDate = new DateOnly(2003, 11, 11),
                address = bob.address,
                gender = "male",
                tuitionPaid = true,

            };
            Console.WriteLine((logan.GetFullName()));
            Console.WriteLine(logan.GetAge());
        }
    }
}
