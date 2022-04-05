namespace LavenderMotors.Entities;

public class Car
{
    public Guid Id { get; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }

    public Car(string brand, string model, string carRegistrationNumber)
    {
        Brand = brand;
        Model = model;
        CarRegistrationNumber = carRegistrationNumber;
    }
}
