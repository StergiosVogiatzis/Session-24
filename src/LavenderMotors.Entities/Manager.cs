namespace LavenderMotors.Entities;

public class Manager
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal SalaryPerMonth { get; set; }

    public Manager(string name, string surname, decimal salaryPerMonth)
    {
        Name = name;
        Surname = surname;
        SalaryPerMonth = salaryPerMonth;
    }
}
