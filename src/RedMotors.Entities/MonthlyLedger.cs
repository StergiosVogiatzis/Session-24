namespace RedMotors.Entities;

public class MonthlyLedger
{
    public uint Year { get; }
    public uint Month { get; }
    public decimal Income { get; }
    public decimal Expenses { get; }
    public decimal Total => Income - Expenses;

    public MonthlyLedger()
    {
    }
}
