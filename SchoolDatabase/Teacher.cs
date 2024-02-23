using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public class Teacher : Person
    {
        private static int nextTeacherId;
        public override byte MinAge => 21;

        private const int MIN_SALARY = 18500;

        // private readonly int teacherId; //Id should be Id because I and D would be two different words if they were both capitalized

        private float _salary;
        public float Salary { get => _salary; set
            {
                if (value < MIN_SALARY)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), 
                        $"Salary must be greater than the statutory minimum of {MIN_SALARY}");
                } 
                //nameof(value) replaces the string ID of the variable, replacing it with "value".
                //This is preferred to typing it out literally
                _salary = value;
            }
        }


        public Teacher() : base (nextTeacherId++) { }
        public Teacher(String firstName, String lastName, 
            DateOnly birthDate, Address address, float salary)
            : base (nextTeacherId++, firstName, lastName, birthDate, address)
        {
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{Id} {FirstName}, {LastName}";
        }
        public static Teacher CreateTeacher()
        {
            Console.Clear();
            Console.WriteLine(" ===== Create Teacher ===== ");


            Console.Write("Input a first name: ");
            String firstName = Program.GetInput();

            while (String.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("First name cannot be null or empty. Please try again.");
                firstName = Program.GetInput();
            }

            Console.Write("Input a last name: ");
            String lastName = Program.GetInput();

            while (String.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Last name cannot be null or empty. Please try again.");
                lastName = Program.GetInput();
            }

            DateOnly birthDate = DateOnly.FromDateTime(DateTime.Now);

            while (true)
            {
                Console.WriteLine("Input a birth date (MM/DD/YYYY): ");
                while (!DateOnly.TryParse(Program.GetInput(), out birthDate))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                if (birthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-21)))
                {
                    Console.WriteLine("Teacher is too young.");
                }
                else break;
            }

            Console.WriteLine("Input a salary.");
            
            float salary;

            while (true)
            {
                if(!float.TryParse(Program.GetInput(), out salary))
                {
                    Console.WriteLine("Input invalid. Please try again.");
                    continue;
                }
                if (salary < 18500)
                {
                    Console.WriteLine("Salary is too low.");
                }
                break;
            }
            
            

            Console.WriteLine("Input a street address.");
            String streetAddress = Program.GetInput();
            //TODO

            Console.WriteLine("Input a city.");
            String city = Program.GetInput();
            //TODO

            Console.WriteLine("Input a state.");
            String state = Program.GetInput();
            //TODO

            Console.WriteLine("Input a zip code.");
            String zipCode = Program.GetInput();
            //TODO

            Address addr = new Address(streetAddress, city, state, zipCode);
            return new Teacher(firstName, lastName, birthDate, addr, salary);

        }
    }
}
