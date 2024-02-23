using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
  

    public class Student : Person
    {
        private static int nextStudentId;

        //Unique identifier
        //private readonly int studentId; //readonly can only be assigned during construction
        //properties are interfaces for backing fields, they do not hold their own data.

        public override byte MinAge => 16;

        private float _gpa;
        public float GPA { get => _gpa; set
            {
                if (value < 0 || value > 4)
                {
                    throw new ArgumentException("GPA must be between 0.0 and 4.0");
                }
                _gpa = value;
            }
        }

        public Student() 
            : base (nextStudentId++) { }

        public Student(String firstName, String lastName, 
            DateOnly birthDate, Address address)
            : this(firstName, lastName, birthDate, address, 0.0f) { }
        
        public Student (String firstName, String lastName,
            DateOnly birthDate, Address address, float gpa) 
            : base (nextStudentId++, firstName, lastName, 
                  birthDate, address)
            //float gpa = 0.0f would also work instead of using another constructor to call this one
        {
            Id = nextStudentId++; //Auto-increments when a new student is created
            GPA = gpa;
        }
        //primary constructors restricts you, since they are readonly by default
        //Constructors accepting the most arguments go towards the bottom

        public static Student CreateStudent()
        {
            Console.Clear();
            Console.WriteLine(" ===== Create Student ===== ");
            

            Console.Write("Input a first name: ");
            String firstName = Program.GetInput();
            
            while(String.IsNullOrWhiteSpace(firstName)) 
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
                if (birthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-16)))
                {
                    Console.WriteLine("Student is too young.");
                }
                else break;
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
            return new Student(firstName, lastName, birthDate, addr);

        }
        public override string ToString()
        {
            return $"{StudentId} {FirstName}, {LastName}";
        }
        /* public String GetFirstName() => _firstName;
        public void SetFirstName(String firstName)
        {
            if (String.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace."); 
            }
            
            this._firstName = firstName;
        }
        
        public String GetLastName() => lastName;
        public void SetLastName(String lastName)
        {
            if (String.IsNullOrEmpty(_firstName))
            {
                throw new ArgumentException("Last name cannot be null, empty, or whitespace.");
            }
            this.lastName = lastName;
        }
        
        public DateOnly GetBirthDate() => birthDate;
        public void SetBirthDate(DateOnly birthDate)
        {
            if (birthDate > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Birth date cannot be in the future.");
            }
            else if(birthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-16)))
            {
                throw new ArgumentException("Too young to attend.");
            }
            this.birthDate = birthDate;
        }
        
        public Address GetAddress() => address;
        public void SetAddress(Address address)
        {
            this.address = address ?? throw new ArgumentNullException("Address cannot be null");
            //?? null coalescing, will perform the first action if the answer result is not null
        }

        public float GetGPA() => gpa;
        public void SetGPA(float gpa)
        {
            if (gpa < 0 || gpa > 4)
            {
                throw new ArgumentException("GPA must be between 0.0 and 4.0");
            }
            this.gpa = gpa;
        }
        */
    }
}
