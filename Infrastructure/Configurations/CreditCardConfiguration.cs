using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> entity)
    {
        entity
            .HasKey(cc => cc.Id)
            .HasName("CreditCard_pkey");

        entity
            .Property(cc => cc.Designation)
            .HasMaxLength(128).IsRequired();

        entity
            .Property(cc => cc.IssueDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(cc => cc.ExpirationDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(cc => cc.CardNumber)
            .HasMaxLength(150).IsRequired();

        entity
            .Property(cc => cc.CVV)
            .HasMaxLength(128).IsRequired();

        entity
            .Property(cc => cc.CreditLimit)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(cc => cc.AvailableCredit)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(cc => cc.CurrentDebt)
            .HasPrecision(20,5).IsRequired();

        entity
            .Property(cc => cc.InterestRate)
            .HasPrecision(20,5).IsRequired();



        entity
            .HasOne(creditcard => creditcard.Currency)
            .WithMany(currency => currency.CreditCards)
            .HasForeignKey(creditcard => creditcard.CurrencyId);

        entity
            .HasOne(creditcard => creditcard.Customer)
            .WithMany(customer => customer.CreditCards)
            .HasForeignKey(creditcard => creditcard.CustomerId);
    }
}
