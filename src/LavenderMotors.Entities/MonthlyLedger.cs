namespace LavenderMotors.Entities;

public class MonthlyLedger
{
    public uint Year { get; }
    public uint Month { get; }
    public decimal Income { get; }
    public decimal Expenses { get; }
    public decimal Total => Income - Expenses;

    public MonthlyLedger(uint year, uint month, decimal income, decimal expenses)
    {
        Year = year;
        Month = month;
        Income = income;
        Expenses = expenses;
    }
}
