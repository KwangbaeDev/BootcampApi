using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PromotionEnterpriseConfiguration : IEntityTypeConfiguration<PromotionEnterprise>
{
    public void Configure(EntityTypeBuilder<PromotionEnterprise> entity)
    {
        //entity.HasKey(p => p.Id);

        //entity
        //    .HasIndex(e => new { e.PromotionId, e.EnterpriseId })
        //    .IsUnique();

        entity.HasKey(pe => new { pe.PromotionId, pe.EnterpriseId });



        entity
            .HasOne(promotionEnterprise => promotionEnterprise.Promotion)
            .WithMany(promotion => promotion.PromotionsEnterprises)
            .HasForeignKey(promotionEnterprise => promotionEnterprise.PromotionId);

        entity
            .HasOne(promotionEnterprise => promotionEnterprise.Enterprise)
            .WithMany(enterprise => enterprise.PromotionsEnterprises)
            .HasForeignKey(promotionEnterprise => promotionEnterprise.EnterpriseId);
    }
}