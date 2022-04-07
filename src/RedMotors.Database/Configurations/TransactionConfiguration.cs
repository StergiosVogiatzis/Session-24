using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedMotors.Database.Configurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions", nameof(RedMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Date).IsRequired();
        builder.HasOne(c => c.Car).WithMany().HasForeignKey(c => c.CarId).IsRequired();
        builder.HasOne(c => c.Customer).WithMany().HasForeignKey(c => c.CustomerId).IsRequired();
        builder.HasOne(c => c.Manager).WithMany().HasForeignKey(c => c.ManagerId).IsRequired();
        builder.HasMany(c => c.Lines).WithOne(c => c.Transaction).HasForeignKey(c => c.TransactionId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Ignore(c => c.TotalPrice);
    }
}
