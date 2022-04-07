namespace RedMotors.Entities;

public class Manager : Person
{
    public decimal SalaryPerMonth { get; set; }
    //public Person Person { get; set; }

    //public Manager(decimal salaryPerMonth)
    //{
    //    SalaryPerMonth = salaryPerMonth;
    //    Engineers = new List<Engineer>();
    //}
    public List<Engineer> Engineers { get; set; }
    public Manager()
    {

    }
}
