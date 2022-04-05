namespace RedMotors.Entities;

public class Engineer
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal SalaryPerMonth { get; set; }
    public string ManagerName { get; set; }
    public Manager Manager { get; set; }
    public Guid ManagerId { get; set; }

    public Engineer(string name, string surname, decimal salaryPerMonth, string managerName)
    {
        Name = name;
        Surname = surname;
        SalaryPerMonth = salaryPerMonth;
        ManagerName = managerName;
    }
}
