using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> entity)
    {
        entity
            .HasKey(af => af.Id);

        entity
            .Property(af => af.Name)
            .IsRequired();


        entity
            .HasMany(service => service.PaymentServices)
            .WithOne(paymentService => paymentService.Service)
            .HasForeignKey(applicationForm => applicationForm.ServiceId);
    }
}
