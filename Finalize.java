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
    
    @Override
    protected void finalize()  
    {
        System.out.println("Удаляем адрес");
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
    
    @Override
    protected void finalize()  
    {
        System.out.println("Удаляем человека");
    }
}


public class Main
{
	public static void main(String[] args) 
	{
		Address adr = new Address("Russia", "Moscow");
		Person prs = new Person("Ivan", "Ivanov", adr);
		
		adr = null;
		prs = null;
		System.gc();
	}
}
