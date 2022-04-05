namespace LavenderMotors.Entities;

public class Customer
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    
    public Customer(string name, string surname, string phone, string TIN)
    {
        Name = name;
        Surname = surname;
        Phone = phone;
        this.TIN = TIN;
    }
}
