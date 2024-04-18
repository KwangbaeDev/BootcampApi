using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CreditConfiguration : IEntityTypeConfiguration<Credit>
{
    public void Configure(EntityTypeBuilder<Credit> entity)
    {
        entity
            .HasKey(c => c.Id);

        entity
            .Property(c => c.Amount)
            .IsRequired();

        entity
            .Property(c => c.Term)
            .IsRequired();

        entity
            .Property(c => c.PendingAmount)
            .IsRequired();

        entity
            .Property(c => c.PendingFee)
            .IsRequired();

        entity
            .Property(c => c.CreditStatus)
            .IsRequired();
    }
}
