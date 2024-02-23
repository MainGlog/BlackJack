using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public record Address(String StreetAddress, String City, String State, String Zip)  //records are a way to create immutable data types
    {
        public override string ToString()
        {
            return $"{this.StreetAddress}, {this.City}, {this.State}, {this.Zip}";
        }
    }

    public abstract class Person
    {
        public abstract byte MinAge { get; } //Abstract property
        public int Id { get; init; }

        private String _firstName;
        public String FirstName
        {
            get => _firstName; set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null, empty, or whitespace.");
                }
                _firstName = value;
            }
        }
        private String _lastName;
        public String LastName
        {
            get => _lastName; set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null, empty, or whitespace.");
                }
                _lastName = value;
            }
        }
        private DateOnly _birthDate;
        public DateOnly BirthDate
        {
            get => _birthDate; set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException("Birth date cannot be in the future.");
                }
                else if (value > DateOnly.FromDateTime(DateTime.Now.AddYears(MinAge)))
                {
                    throw new ArgumentException("Too young to attend.");
                }
                _birthDate = value;
            }
        }
        private Address _address;
        public Address Address
        {
            get => _address; set
            {
                _address = value ?? throw new ArgumentNullException("Address cannot be null");

            }
        }

        public Person(int id)
        {
            Id = id;
        }
        public Person(int id, String firstName, String lastName,
            DateOnly birthDate, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Address = address;
        }
    }
}
