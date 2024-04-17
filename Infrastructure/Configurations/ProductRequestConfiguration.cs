using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductRequestConfiguration : IEntityTypeConfiguration<ProductRequests>
{
    public void Configure(EntityTypeBuilder<ProductRequests> entity)
    {
        entity
            .HasKey(pr => pr.Id);

        entity
            .Property(pr => pr.Dateofapplication)
            .IsRequired();

        entity
            .Property(pr => pr.ApprovalDate)
            .IsRequired();


        entity
            .HasOne(productRequest => productRequest.Product)
            .WithMany(product => product.ProductRequests)
            .HasForeignKey(productRequest => productRequest.ProductId);
    }
}
