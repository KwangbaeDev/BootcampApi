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
            .Property(ps => ps.Description)
            .IsRequired();



        entity
            .HasOne(paymentService => paymentService.Movement)
            .WithMany(movement => movement.PaymentServices)
            .HasForeignKey(paymentService => paymentService.MovementId);


    }
}
