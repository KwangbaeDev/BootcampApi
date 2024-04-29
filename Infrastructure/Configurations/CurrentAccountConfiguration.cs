using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>
{
    public void Configure(EntityTypeBuilder<CurrentAccount> entity)
    {
        entity
            .HasKey(ca => ca.Id).
            HasName("CurrentAccount_pkey");

        entity
            .Property(ca => ca.OperationalLimit)
            .HasPrecision(20, 5);

        entity
            .Property(ca => ca.MonthAverage)
            .HasPrecision(20, 5);

        entity
            .Property(ca => ca.Interest)
            .HasPrecision(10, 5);



        entity
            .HasOne(currentaccount => currentaccount.Account)
            .WithOne(p => p.CurrentAccount)
            .HasForeignKey<CurrentAccount>(d => d.AccountId);
    }
}
