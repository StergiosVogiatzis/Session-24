using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedMotors.Database.Configurations;

internal sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars", nameof(RedMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Brand).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Model).HasMaxLength(50).IsRequired();
        builder.Property(c => c.CarRegistrationNumber).HasMaxLength(50).IsRequired();
    }
}
