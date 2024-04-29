using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity
            .HasKey(c => c.Id)
            .HasName("Customer_pkey");

        entity
            .Property(c => c.Name)
            .HasMaxLength(300).IsRequired();

        entity
            .Property(c => c.Lastname)
            .HasMaxLength(300);

        entity
            .Property(c => c.DocumentNumber)
            .HasMaxLength(150)
            .IsRequired();

        entity
            .Property(c => c.Address)
            .HasMaxLength(400);

        entity
            .Property(c => c.Mail)
            .HasMaxLength(100);

        entity
            .Property(c => c.Phone)
            .HasMaxLength(150);

        entity
            .Property(c => c.Birth)
            .HasColumnType("timestamp without time zone");



        entity
            .HasOne(customer => customer.Bank)
            .WithMany(bank => bank.Customers)
            .HasForeignKey(customer => customer.BankId);

        entity
            .HasMany(customer => customer.Accounts)
            .WithOne(account => account.Customer)
            .HasForeignKey(acount => acount.CustomerId);

        entity
            .HasMany(customer => customer.ApplicationForms)
            .WithOne(applicationForm => applicationForm.Customer)
            .HasForeignKey(applicationForn => applicationForn.CustomerId);
    }
}
