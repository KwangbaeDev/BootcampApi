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
            .Property(e => e.Amount)
            .IsRequired();

        entity
            .Property(e => e.TransferredDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        entity
            .Property(e => e.Concept)
            .IsRequired();



        entity
            .HasOne(transfer => transfer.OriginAccount)
            .WithMany(originAccount => originAccount.Transfers)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        //entity
        //    .HasOne(transfer => transfer.TargetAccount)
        //    .WithMany(targetAccount => targetAccount.Transfers)
        //    .HasForeignKey(transfer => transfer.TargetAccountId)
        //    .IsRequired(false);
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
