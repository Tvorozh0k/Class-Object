using System;

namespace ConsoleApp3
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }

        public Address(string country, string city)
        {
            Country = country;
            City = city;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            var adr = (Address)obj;
            
            return (Country == adr.Country) && (City == adr.City);
        }

        public override string ToString()
        {
            return City + ", " + Country;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person (string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            var prs = (Person)obj;

            return (FirstName == prs.FirstName) && (LastName == prs.LastName) && Address.Equals(prs.Address);
        }

        public override string ToString()
        {
            return FirstName + ' ' + LastName + " lives in " + Address.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address adr = new Address("Russia", "Moscow");
            Person prs = new Person("Ivan", "Ivanov", adr);

            // Address
            Console.WriteLine(adr.GetType());

            // Person
            Console.WriteLine(prs.GetType());
        }
    }
}
