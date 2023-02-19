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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address adr = new Address("Russia", "Moscow");
            Person prs = new Person("Ivan", "Ivanov", adr);

            // bool
            bool b = true;
            Console.WriteLine("Bool: {0}", b.GetHashCode());

            // int
            int i = 5;
            Console.WriteLine("Int: {0}", i.GetHashCode());

            // double
            double d = 3.14;
            Console.WriteLine("Double: {0}", d.GetHashCode());

            // char 
            char c = 'A';
            Console.WriteLine("Char: {0}", c.GetHashCode());

            // string
            string s = "Moscow";
            Console.WriteLine("String: {0}", s.GetHashCode());

            // Address
            Console.WriteLine("String: {0}", adr.GetHashCode());

            // Person
            Console.WriteLine("String: {0}", prs.GetHashCode());
        }
    }
}
