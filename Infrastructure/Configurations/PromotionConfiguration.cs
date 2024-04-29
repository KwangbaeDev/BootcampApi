using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> entity)
    {
        entity
            .HasKey(p => p.Id);

        entity
            .Property(p => p.Start)
            .IsRequired();

        entity
            .Property(p => p.End)
            .IsRequired();

        entity
            .Property(p => p.Discount)
            .IsRequired();



        entity
            .HasMany(promotion => promotion.PromotionsEnterprises)
            .WithOne(promotionEnterprise => promotionEnterprise.Promotion)
            .HasForeignKey(promotionEnterprise => promotionEnterprise.PromotionId);
    }
}
