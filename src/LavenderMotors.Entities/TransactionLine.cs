namespace LavenderMotors.Entities;

public class TransactionLine
{
    private Transaction? _transaction;
    private ServiceTask? _serviceTask;
    private Engineer? _engineer;

    public Guid Id { get; }

    public Transaction Transaction
    {
        get => _transaction ?? throw Utilities.CreateUnboundValueAccessException();
        set => _transaction = value;
    }

    public Guid TransactionId { get; set; }

    public ServiceTask ServiceTask
    {
        get => _serviceTask ?? throw Utilities.CreateUnboundValueAccessException();
        set => _serviceTask = value;
    }

    public Guid ServiceTaskId { get; set; }

    public Engineer Engineer
    {
        get => _engineer ?? throw Utilities.CreateUnboundValueAccessException();
        set => _engineer = value;
    }

    public Guid EngineerId { get; set; }

    public decimal Hours { get; }

    public decimal PricePerHour { get; }

    public decimal Price { get; set; }


    public TransactionLine(decimal hours, decimal pricePerHour)
    {
        Hours = hours;
        PricePerHour = pricePerHour;
    }
}
