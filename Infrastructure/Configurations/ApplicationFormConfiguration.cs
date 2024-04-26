using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ApplicationFormConfiguration : IEntityTypeConfiguration<ApplicationForm>
{
    public void Configure(EntityTypeBuilder<ApplicationForm> entity)
    {
        entity
            .HasKey(af => af.Id);

        entity
            .Property(af => af.Description)
            .IsRequired();

        entity
            .Property(af => af.ApplicationDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        entity
            .Property(af => af.ApprovalDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(af => af.RejectionDate)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(af => af.RequestStatus)
            .IsRequired();




        entity
            .HasOne(applicationForm => applicationForm.Customer)
            .WithMany(customer => customer.ApplicationForms)
            .HasForeignKey(applicationFrom => applicationFrom.CustomerId);

        entity
            .HasOne(applicationForm => applicationForm.Currency)
            .WithMany(currency => currency.ApplicationForms)
            .HasForeignKey(applicationForm => applicationForm.CurrencyId);

        entity
            .HasOne(applicationForm => applicationForm.Product)
            .WithMany(product => product.ApplicationForms)
            .HasForeignKey(applicationForm => applicationForm.ProductId);
    }
}
