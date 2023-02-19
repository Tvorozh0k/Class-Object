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
		
		// Проверка на сравнение типов 
	    System.out.printf("Address и Int: %b\n", adr.equals(5));
	    System.out.printf("Person и Address: %b\n", prs.equals(adr));
	         
	    // Address
	    Address new_adr = new Address("Russia", "Moscow");
	 
	    System.out.printf("Address и Address: %b\n", adr.equals(new_adr));
	 
	    new_adr.Country = null;
	 
	    System.out.printf("Address и Address: %b\n", adr.equals(new_adr));
	 
	    // Person
	    Person new_prs = new Person("Ivan", "Ivanov", adr);
	 
	    System.out.printf("Person и Person: %b\n", prs.equals(new_prs));
	 
	    new_prs.Address = new_adr;
	 
	    System.out.printf("Person и Person: %b\n", prs.equals(new_prs));

	}
}
