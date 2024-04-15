﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Promotion_pkey");

        entity
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();


        entity
            .Property(e => e.DurationTime);

        entity
            .Property(e => e.PercentageOff)
            .HasPrecision(20, 5);


        entity
            .HasOne(promotion => promotion.CompanyBusinesses)
            .WithMany(companybusiness => companybusiness.Promotions)
            .HasForeignKey(promotion => promotion.CompanyBusinessId);
    }
}
