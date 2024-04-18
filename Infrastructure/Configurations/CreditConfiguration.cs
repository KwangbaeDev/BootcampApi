using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CreditConfiguration : IEntityTypeConfiguration<Credit>
{
    public void Configure(EntityTypeBuilder<Credit> entity)
    {
        entity
            .HasKey(c => c.Id);

        entity
            .Property(c => c.Amount)
            .IsRequired();

        entity
            .Property(c => c.Term)
            .IsRequired();

        entity
            .Property(c => c.PendingAmount)
            .IsRequired();

        entity
            .Property(c => c.PendingFee)
            .IsRequired();

        entity
            .Property(c => c.CreditStatus)
            .IsRequired();


        entity
            .HasOne(credit => credit.CreditRequest)
            .WithMany(creditRequest => creditRequest.Credits)
            .HasForeignKey(credit => credit.CreditRequestId);

        entity
            .HasOne(credit => credit.Customer)
            .WithMany(customer => customer.Credits)
            .HasForeignKey(credit => credit.CustomerId);

        entity
            .HasOne(credit => credit.Currency)
            .WithMany(currency => currency.Credits)
            .HasForeignKey(credit => credit.CurrencyId);
    }
}
