using RedMotors.Database;
using RedMotors.Database.Repository;
using RedMotors.Entities;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddRedMotorsDatabase(this IServiceCollection serviceDescriptors)
    {
        return serviceDescriptors
            //.AddDbContext<GarageContext>()
            .AddTransient<IEntityRepo<Customer>, CustomerRepo>()
            .AddTransient<IEntityRepo<Car>, CarRepo>()
            .AddTransient<IEntityRepo<Manager>, ManagerRepo>()
            .AddTransient<IEntityRepo<ServiceTask>, ServiceTaskRepo>()
            .AddTransient<IEntityRepo<Transaction>, TransactionRepo>()
            ;
    }
}
