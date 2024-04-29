using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class SavingAccountConfiguration : IEntityTypeConfiguration<SavingAccount>
{
    public void Configure(EntityTypeBuilder<SavingAccount> entity)
    {
        entity
            .HasKey(sa => sa.Id)
            .HasName("SavingAccount_pkey");

        entity
            .Property(sa => sa.HolderName)
            .HasMaxLength(100);



        entity
            .HasOne(savingAccount => savingAccount.Account)
            .WithOne(account => account.SavingAccount)
            .HasForeignKey<SavingAccount>(savingAccount => savingAccount.AccountId);
    }
}
