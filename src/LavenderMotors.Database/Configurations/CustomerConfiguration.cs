using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavenderMotors.Database.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", nameof(LavenderMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Surname).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(10).IsRequired();
        builder.Property(c => c.TIN).HasMaxLength(10).IsRequired();
    }
}
