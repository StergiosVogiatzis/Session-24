using RedMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedMotors.Database.Configurations;

internal sealed class EngineerConfiguration : IEntityTypeConfiguration<Engineer>
{
    public void Configure(EntityTypeBuilder<Engineer> builder)
    {
        builder.ToTable("Engineer", nameof(RedMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Surname).HasMaxLength(50).IsRequired();
        builder.Property(c => c.SalaryPerMonth).HasMaxLength(50).IsRequired();
        builder.HasOne(engineer => engineer.Manager).WithMany(manager => manager.Engineers).HasForeignKey(engineer => engineer.ManagerId).OnDelete(DeleteBehavior.NoAction);
    }
}
