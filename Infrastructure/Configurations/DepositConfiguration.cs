using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> entity)
    {
        entity
            .HasKey(d => d.Id);

        entity
            .Property(e => e.Amount)
            //.HasPrecision(20, 5)
            .IsRequired();

        entity
            .Property(e => e.DepositDateTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired();



        entity
            .HasOne(deposit => deposit.Account)
            .WithMany(account => account.Deposits)
            .HasForeignKey(deposit => deposit.AccountId);

        entity
            .HasOne(deposit => deposit.Bank)
            .WithMany(bank => bank.Deposits)
            .HasForeignKey(deposit => deposit.BankId);


        //entity
        //    .HasOne(deposit => deposit.Movement)
        //    .WithMany(movement => movement.Deposits)
        //    .HasForeignKey(deposit => deposit.MovementId);
    }
}
