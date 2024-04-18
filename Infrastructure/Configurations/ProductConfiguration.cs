using Core.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity
            .HasKey(p => p.Id);

        entity
            .Property(p => p.ProductType)
            .IsRequired();

        entity
            .HasOne(product => product.ApplicationForm)
            .WithOne(applicationForm => applicationForm.Product)
            .HasForeignKey<Product>(product => product.ApplicationFormId);
    }
}
