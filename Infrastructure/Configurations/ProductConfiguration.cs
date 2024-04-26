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
            .Property(p => p.Name)
            .IsRequired();



        entity
            .HasMany(product => product.ApplicationForms)
            .WithOne(applicationForm => applicationForm.Product)
            .HasForeignKey(applicationForm => applicationForm.ProductId);
    }
}
