using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> entity)
    {
        entity
            .ToTable("Currencies");

        entity
            .HasKey(c => c.Id)
            .HasName("Currency_pkey");

        entity
            .Property(c => c.Name)
            .HasMaxLength(50);

        entity
            .Property(c => c.BuyValue)
            .HasColumnType("numeric(20,5)");

        entity
            .Property(c => c.SellValue)
            .HasColumnType("numeric(20,5)");



        entity
            .HasMany(currency => currency.Accounts)
            .WithOne(account => account.Currency)
            .HasForeignKey(account => account.CurrencyId);

        entity
            .HasMany(currency => currency.ApplicationForms)
            .WithOne(applicationForm => applicationForm.Currency)
            .HasForeignKey(applicationForm => applicationForm.CurrencyId);

        entity
            .HasMany(currency => currency.Transfers)
            .WithOne(transfer => transfer.Currency)
            .HasForeignKey(transfer => transfer.CurrencyId);
    }
}