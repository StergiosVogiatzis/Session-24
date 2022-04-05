namespace LavenderMotors.Entities;

public class Transaction
{
    private Customer? _customer;
    private Car? _car;
    private Manager? _manager;

    public Guid Id { get; }

    public DateTime Date { get; set; }

    public Customer Customer
    {
        get => _customer ?? throw Utilities.CreateUnboundValueAccessException();
        set => _customer = value;
    }

    public Guid CustomerId { get; set; }

    public Car Car
    {
        get => _car ?? throw Utilities.CreateUnboundValueAccessException();
        set => _car = value;
    }

    public Guid CarId { get; set; }

    public Manager Manager
    {
        get => _manager ?? throw Utilities.CreateUnboundValueAccessException();
        set => _manager = value;
    }

    public Guid ManagerId { get; set; }

    public decimal TotalPrice => Lines.Sum(x => x.Price);

    public List<TransactionLine> Lines { get; set; } = new();
}
