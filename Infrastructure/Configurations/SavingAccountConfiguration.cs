﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class SavingAccountConfiguration : IEntityTypeConfiguration<SavingAccount>
{
    public void Configure(EntityTypeBuilder<SavingAccount> entity)
    {
        entity.HasKey(e => e.Id).HasName("SavingAccount_pkey");
        entity.Property(e => e.HolderName).HasMaxLength(100);


        entity
            .HasOne(savingAccount => savingAccount.Accounts)
            .WithMany(account => account.SavingAccounts)
            .HasForeignKey(savingAccount => savingAccount.Id);
    }
}
