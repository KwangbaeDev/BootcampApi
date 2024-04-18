﻿using Core.Entities;
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
            .Property(af => af.Name)
            .IsRequired();

        entity
            .Property(af => af.Lastname)
            .IsRequired();

        entity
            .Property(af => af.DocumentNumber)
            .IsRequired();

        entity
            .Property(af => af.Address)
            .IsRequired();

        entity
            .Property(af => af.Mail)
            .IsRequired();

        entity
            .Property(af => af.Phone)
            .IsRequired();

        entity
            .Property(af => af.Descripcion)
            .IsRequired();

        entity
            .Property(af => af.ApplicationDate)
            .IsRequired();

        entity
            .Property(af => af.ApprovalDate);

        entity
            .Property(af => af.RejectionDate);

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
            .WithOne(product => product.ApplicationForm)
            .HasForeignKey<Product>(product => product.ApplicationFormId);
    }
}
