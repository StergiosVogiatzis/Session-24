namespace RedMotors.Entities;

public class ServiceTask
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }

    public ServiceTask()
    {
    }
}
