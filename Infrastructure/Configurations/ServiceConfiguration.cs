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
            .HasKey(s => s.Id);

        entity
            .Property(s => s.Name)
            .IsRequired();



        entity
            .HasMany(service => service.PaymentServices)
            .WithOne(paymentService => paymentService.Service)
            .HasForeignKey(paymentService => paymentService.ServiceId);
    }
}
