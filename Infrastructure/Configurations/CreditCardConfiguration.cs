using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("CreditCard_pkey");

        entity
            .Property(e => e.Designation)
            .HasMaxLength(128).IsRequired();

        entity
            .Property(e => e.IssueDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(e => e.ExpirationDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(e => e.CardNumber)
            .HasMaxLength(150).IsRequired();

        entity
            .Property(e => e.CVV)
            .HasMaxLength(128).IsRequired();

        entity
            .Property(e => e.CreditLimit)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(e => e.AvailableCredit)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(e => e.CurrentDebt)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(e => e.InterestRate)
            .HasPrecision(20,5).IsRequired();



        entity
            .HasOne(creditcard => creditcard.Currency)
            .WithMany(currency => currency.CreditCards)
            .HasForeignKey(creditcard => creditcard.CurrencyId);

        entity
            .HasOne(creditcard => creditcard.Customer)
            .WithMany(customer => customer.CreditCards)
            .HasForeignKey(creditcard => creditcard.CustomerId);

        entity
            .HasOne(creditCard => creditCard.Product)
            .WithMany(product => product.CreditCards)
            .HasForeignKey(creditCard => creditCard.ProductId);
    }
}
