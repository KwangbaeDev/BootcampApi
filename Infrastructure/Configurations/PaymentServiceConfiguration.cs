using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PaymentServiceConfiguration : IEntityTypeConfiguration<PaymentService>
{
    public void Configure(EntityTypeBuilder<PaymentService> entity)
    {
        entity
            .HasKey(ps => ps.Id);


        entity
            .Property(ps => ps.Amount)
            .IsRequired();

        entity
            .Property(ps => ps.Concept)
            .IsRequired();

        entity
            .Property(ps => ps.PaymentServiceDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();



        entity
            .HasOne(paymentService => paymentService.Account)
            .WithMany(account => account.PaymentServices)
            .HasForeignKey(paymentService => paymentService.AccountId);


        entity
            .HasOne(paymentService => paymentService.Service)
            .WithMany(service => service.PaymentServices)
            .HasForeignKey(paymentService => paymentService.ServiceId);
    }
}
