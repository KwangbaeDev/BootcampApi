using Core.Entities;
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
            .Property(p => p.Tipo)
            .IsRequired();


        entity
            .HasMany(produc => produc.Credits)
            .WithOne(credit => credit.Product)
            .HasForeignKey(product => product.ProducId);

        entity
            .HasMany(product => product.CreditCards)
            .WithOne(creditCard => creditCard.Product)
            .HasForeignKey(product => product.ProductId);

        entity
            .HasMany(product => product.CurrentAccounts)
            .WithOne(currentAccount => currentAccount.Product)
            .HasForeignKey(product => product.ProductId);

        entity
            .HasMany(product => product.Currencies)
            .WithOne(currency => currency.Product)
            .HasForeignKey(product => product.ProductId);

        entity
            .HasMany(product => product.ProductRequests)
            .WithOne(productRequest => productRequest.Product)
            .HasForeignKey(product => product.ProductId);
    }
}
