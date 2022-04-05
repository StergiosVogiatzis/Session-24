namespace RedMotors.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }

    public Car()
    {
        Id = Guid.NewGuid();
    }
}
