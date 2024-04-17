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
            .Property(c => c.CreditAmount)
            .IsRequired();

        entity
            .Property(c => c.PreferredTerm)
            .IsRequired();


        entity
            .HasOne(credit => credit.Product)
            .WithMany(product => product.Credits)
            .HasForeignKey(credit => credit.ProducId);
    }
}
