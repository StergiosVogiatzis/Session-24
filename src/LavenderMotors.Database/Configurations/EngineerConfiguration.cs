using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavenderMotors.Database.Configurations;

internal sealed class EngineerConfiguration : IEntityTypeConfiguration<Engineer>
{
    public void Configure(EntityTypeBuilder<Engineer> builder)
    {
        builder.ToTable("Engineer", nameof(LavenderMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Surname).HasMaxLength(50).IsRequired();
        builder.Property(c => c.SalaryPerMonth).HasMaxLength(50).IsRequired();
        builder.HasOne(c => c.Manager).WithMany().HasForeignKey(c => c.ManagerId).OnDelete(DeleteBehavior.NoAction);
    }
}
