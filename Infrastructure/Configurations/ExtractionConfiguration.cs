using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExtractionConfiguration : IEntityTypeConfiguration<Extraction>
{
    public void Configure(EntityTypeBuilder<Extraction> entity)
    {
        entity
            .HasKey(e => e.Id);

        entity
            .Property(e => e.Amount)
            .IsRequired();

        entity
            .Property(e => e.ExtractionDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();



        entity
            .HasOne(extraction => extraction.Account)
            .WithMany(account => account.Extractions)
            .HasForeignKey(extraction => extraction.AccountId);

        entity
            .HasOne(extraction => extraction.Bank)
            .WithMany(bank => bank.Extractions)
            .HasForeignKey(extraction => extraction.BankId);
    }
}
