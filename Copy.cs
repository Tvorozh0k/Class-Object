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

        ~Address()
        {
            Console.WriteLine("Удаляем адрес");
        }

        public Address ShallowCopy()
        {
            return (Address)this.MemberwiseClone();
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

        ~Person()
        {
            Console.WriteLine("Удаляем человека");
        }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Address = Address.ShallowCopy();
            return other;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address adr = new Address("Russia", "Moscow");
            Person prs = new Person("Ivan", "Ivanov", adr);

            Address adr1 = adr.ShallowCopy();
            Person prs1 = prs.DeepCopy();

            adr.City = "Saratov";

            Console.WriteLine(adr1.Equals(adr));
            Console.WriteLine(prs1.Equals(prs));
        }
    }
}
