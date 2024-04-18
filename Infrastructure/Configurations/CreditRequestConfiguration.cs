using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CreditRequestConfiguration : IEntityTypeConfiguration<CreditRequest>
{
    public void Configure(EntityTypeBuilder<CreditRequest> entity)
    {
        entity
            .HasKey(cr => cr.Id);

        entity
            .Property(cr => cr.Amount)
            .IsRequired();

        entity
            .Property(cr => cr.Term)
            .IsRequired();

        entity
            .Property(cr => cr.ApplicationDate)
            .IsRequired();

        entity
            .Property(cr => cr.ApprovalDate);

        entity
            .Property(cr => cr.RejectionDate);

        entity
            .Property(cr => cr.RequestStatus)
            .IsRequired();


        entity
            .HasOne(creditRequest => creditRequest.Customer)
            .WithMany(customer => customer.CreditRequests)
            .HasForeignKey(creditRequest => creditRequest.CustomerId);

        entity
            .HasOne(creditRequest => creditRequest.Currency)
            .WithMany(currency => currency.CreditRequests)
            .HasForeignKey(creditRequest => creditRequest.CurrencyId);

        entity
            .HasMany(creditRequest => creditRequest.Credits)
            .WithOne(credit => credit.CreditRequest)
            .HasForeignKey(creditRequest => creditRequest.CreditRequestId);
    }
}
