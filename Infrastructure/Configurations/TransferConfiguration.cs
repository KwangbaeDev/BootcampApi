using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity
            .HasKey(t => t.Id);

        entity
            .Property(t => t.Amount)
            .IsRequired();

        entity
            .Property(t => t.TransferredDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        entity
            .Property(t => t.Concept)
            .IsRequired();



        entity
            .HasOne(transfer => transfer.OriginAccount)
            .WithMany(originAccount => originAccount.Transfers)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        entity
            .HasOne<Account>()
            .WithMany(destinationAccount => destinationAccount.Transfers)
            .HasForeignKey(transfer => transfer.DestinationAccountId);

        entity
            .HasOne(transfer => transfer.Bank)
            .WithMany(bank => bank.Transfers)
            .HasForeignKey(transfer => transfer.DestinationBankId);

        entity
            .HasOne(transfer => transfer.Currency)
            .WithMany(currency => currency.Transfers)
            .HasForeignKey(transfer => transfer.CurrencyId);



    }
}
