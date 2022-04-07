using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedMotors.Database.Configurations;

internal sealed class ServiceTaskConfiguration : IEntityTypeConfiguration<ServiceTask>
{
    public void Configure(EntityTypeBuilder<ServiceTask> builder)
    {
        builder.ToTable("ServiceTasks", nameof(RedMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Hours).IsRequired().HasPrecision(10, 2);
    }
}
