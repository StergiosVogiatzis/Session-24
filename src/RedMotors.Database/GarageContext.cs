using RedMotors.Database.Configurations;
using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace RedMotors.Database;

public class GarageContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<ServiceTask> ServiceTasks { get; set; }
    public DbSet<Engineer> Engineers { get; set; } = null!;
    public DbSet<Manager> Managers { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    //TODO: needs arguments in the mothly leger model
    //public Task<List<MonthlyLedger>> GetMonthlyLedgerAsync() =>
    //    Transactions
    //        .Include(x => x.Lines)
    //        .GroupBy(x => new { x.Date.Year, x.Date.Month })
    //        .Select(x => new MonthlyLedger((uint)x.Key.Year, (uint)x.Key.Month, x.Sum(y => y.Lines.Sum(z => z.Price)), Managers.Sum(y => y.SalaryPerMonth) + Engineers.Sum(y => y.SalaryPerMonth)))
    //        .ToListAsync();

    public GarageContext()
    {
        _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=RedMotors;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceTaskConfiguration());
        modelBuilder.ApplyConfiguration(new EngineerConfiguration());
        modelBuilder.ApplyConfiguration(new ManagerConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionLineConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
