using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configurations;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Bank_pkey");

        entity
            .Property(e => e.Name)
            .HasMaxLength(300)
            .IsRequired();

        entity
            .Property(e => e.Phone)
            .HasMaxLength(150)
            .IsRequired();

        entity
            .Property(e => e.Mail)
            .HasMaxLength(100)
            .IsRequired();

        entity
            .Property(e => e.Address)
            .HasMaxLength(400)
            .IsRequired();




        entity
            .HasMany(bank => bank.Customers)
            .WithOne(customer => customer.Bank)
            .HasForeignKey(customer => customer.BankId);

        entity
            .HasMany(bank => bank.Transfers)
            .WithOne(transfer => transfer.Bank)
            .HasForeignKey(transfer => transfer.DestinationBankId);

        entity
            .HasMany(bank => bank.Deposits)
            .WithOne(deposit => deposit.Bank)
            .HasForeignKey(deposit => deposit.BankId);

        entity
            .HasMany(bank => bank.Extractions)
            .WithOne(extraction => extraction.Bank)
            .HasForeignKey(extraction => extraction.BankId);
    }
}
