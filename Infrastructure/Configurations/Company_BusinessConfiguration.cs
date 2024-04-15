using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class Company_BusinessConfiguration : IEntityTypeConfiguration<Company_Business>
{
    public void Configure(EntityTypeBuilder<Company_Business> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Company_Business_pkey");

        entity
            .Property(e => e.Name)
            .HasMaxLength(100).IsRequired();

        entity
            .Property(e => e.Address)
            .HasMaxLength(100);


        entity
            .Property(e => e.Phone)
            .HasMaxLength(100);

        entity
            .Property(e => e.Email)
            .HasMaxLength(100);

        entity
            .HasMany(companybusiness => companybusiness.Promotions)
            .WithOne(promotion => promotion.CompanyBusinesses)
            .HasForeignKey(companybusiness => companybusiness.CompanyBusinessId);
    }
}
