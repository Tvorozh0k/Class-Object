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

            // Проверка на сравнение типов 
	        Console.WriteLine("Address и Int: {0}", adr.Equals(5));
	        Console.WriteLine("Person и Address: {0}", prs.Equals(adr));
	 
	        // Address
	        Address new_adr = new Address("Russia", "Moscow");
	 
	        Console.WriteLine("Address и Address: {0}", adr.Equals(new_adr));
	          
	        new_adr.Country = null;
	 
	        Console.WriteLine("Address и Address: {0}", adr.Equals(new_adr));
	 
	        // Person
	        Person new_prs = new Person("Ivan", "Ivanov", adr);
	 
	        Console.WriteLine("Person и Person: {0}", prs.Equals(new_prs));
	 
	        new_prs.Address = new_adr;
	 
	        Console.WriteLine("Person и Person: {0}", prs.Equals(new_prs));

        }
    }
}
