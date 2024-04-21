﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Movement_pkey");

        entity
            .Property(m => m.Destination)
            .HasMaxLength(150)
            .IsRequired();

        entity
            .Property(m => m.Amount)
            .HasPrecision(20, 5);

        entity
            .Property(m => m.TransferredDateTime)
            .HasColumnType("timestamp without time zone");

        entity
            .Property(m => m.MovementType)
            .IsRequired();



        entity
            .HasOne(movement => movement.Account)
            .WithMany(account => account.Movements)
            .HasForeignKey(movement => movement.AccountId);
    }
}
