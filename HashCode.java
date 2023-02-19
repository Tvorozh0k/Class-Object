class Address
{
    public String Country, City;
    
    Address (String country, String city)
    {
        Country = country;
        City = city;
    }
    
    @Override
    public boolean equals(Object obj)
    {
        if (!(obj instanceof Address)) return false;
            
        Address adr = (Address) obj;
         
        return (Country == adr.Country) && (City == adr.City);
    }
}

class Person
{
    public String FirstName, LastName;
    public Address Address;
    
    Person (String firstName, String lastName, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
    
    @Override
    public boolean equals(Object obj)
    {
        if (!(obj instanceof Person)) return false;

        Person prs = (Person)obj;

        return (FirstName == prs.FirstName) && (LastName == prs.LastName) && Address.equals(prs.Address);
    }
}


public class Main
{
	public static void main(String[] args) 
	{
		Address adr = new Address("Russia", "Moscow");
		Person prs = new Person("Ivan", "Ivanov", adr);
		
		// bool
        Boolean b = new Boolean(true);
        System.out.printf("Bool: %d\n", b.hashCode());

        // int
        Integer i = new Integer(5);
        System.out.printf("Int: %d\n", i.hashCode());

        // double
        Double d = new Double(3.14);
        System.out.printf("Double: %d\n", d.hashCode());

        // char 
        Character c = new Character('A');
        System.out.printf("Char: %d\n", c.hashCode());

        // string
        String s = new String("Moscow");
        System.out.printf("String: %d\n", s.hashCode());

        // Address
        System.out.printf("Address: %d\n", adr.hashCode());

        // Person
        System.out.printf("Person: %d\n", prs.hashCode());
	}
}
