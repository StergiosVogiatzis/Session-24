namespace RedMotors.Entities;

public class Manager : Person
{
    public decimal SalaryPerMonth { get; set; }
    //public Person Person { get; set; }

    public Manager(decimal salaryPerMonth)
    {
        SalaryPerMonth = salaryPerMonth;
        //Person = new Person();
    }
    public Manager()
    {

    }
}
