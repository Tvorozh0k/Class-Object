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
    
    @Override 
    public String toString()
    {
        return City + ", " + Country;
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
    
    @Override 
    public String toString()
    {
        return FirstName + ' ' + LastName + " lives in " + Address.toString();
    }
}


public class Main
{
	public static void main(String[] args) 
	{
		Address adr = new Address("Russia", "Moscow");
		Person prs = new Person("Ivan", "Ivanov", adr);
        
        // Address
        System.out.println(adr.getClass());

        // Person
        System.out.println(prs.getClass());
	}
}
