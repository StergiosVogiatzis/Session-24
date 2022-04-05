namespace RedMotors.Entities;

public class Engineer : Person
{
    public decimal SalaryPerMonth { get; set; }
    public Manager Manager { get; set; }
    public Guid ManagerId { get; set; }

    public Engineer()
    {
    }
}
