using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavenderMotors.Database.Configurations;

internal sealed class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
{
    public void Configure(EntityTypeBuilder<TransactionLine> builder)
    {
        builder.ToTable("TransactionLines", nameof(LavenderMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.HasOne(c => c.Transaction).WithMany(c => c.Lines).HasForeignKey(c => c.TransactionId).IsRequired();
        builder.HasOne(c => c.ServiceTask).WithMany().HasForeignKey(c => c.ServiceTaskId).IsRequired();
        builder.HasOne(c => c.Engineer).WithMany().HasForeignKey(c => c.EngineerId).IsRequired();
        builder.Property(c => c.Hours).IsRequired().HasPrecision(4, 2);
        builder.Property(c => c.PricePerHour).IsRequired().HasPrecision(8, 2);
        builder.Property(c => c.Price).HasComputedColumnSql("[Hours] * [PricePerHour]").HasPrecision(8, 2);
    }
}
