using LavenderMotors.Database;
using LavenderMotors.Database.Repository;
using LavenderMotors.Entities;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddLavenderMotorsDatabase(this IServiceCollection serviceDescriptors)
    {
        return serviceDescriptors
            .AddDbContext<GarageContext>()
            .AddTransient<IEntityRepo<Customer>, CustomerRepo>()
            .AddTransient<IEntityRepo<Car>, CarRepo>()
            .AddTransient<IEntityRepo<Manager>, ManagerRepo>()
            .AddTransient<IEntityRepo<ServiceTask>, ServiceTaskRepo>()
            .AddTransient<IEntityRepo<Transaction>, TransactionRepo>()
            ;
    }
}
