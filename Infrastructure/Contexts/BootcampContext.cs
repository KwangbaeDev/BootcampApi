using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class BootcampContext : DbContext
{
    public BootcampContext()
    {
    }

    public BootcampContext(DbContextOptions<BootcampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<CajaAhorro> CajaAhorros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<CuentaCorriente> CuentaCorrientes { get; set; }

    public virtual DbSet<Movimientos> Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.ToTable("Banco");

            entity.HasKey(e => e.Id).HasName("Banco_pkey");

            entity.Property(e => e.Direccion).HasMaxLength(400);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(300);
            entity.Property(e => e.Telefono).HasMaxLength(150);
        });

        modelBuilder.Entity<CajaAhorro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CajaAhorro_pkey");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.NombreTarjeta).HasMaxLength(100);
            entity.Property(e => e.TipoDeposito).HasMaxLength(50);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.CajaAhorro)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CajaAhorro_CuentaId_fkey");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cliente_pkey");

            entity.Property(e => e.Apellido).HasMaxLength(300);
            entity.Property(e => e.Celular).HasMaxLength(150);
            entity.Property(e => e.Direccion).HasMaxLength(400);
            entity.Property(e => e.Documento).HasMaxLength(150);
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(300);

            entity.HasOne(d => d.Banco).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.BancoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cliente_BancoId_fkey");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cuenta_pkey");

            entity.Property(e => e.NumeroCuenta).HasMaxLength(100);
            entity.Property(e => e.Saldo).HasPrecision(20, 5);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Titular).HasMaxLength(300);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cuenta_ClienteId_fkey");
        });

        modelBuilder.Entity<CuentaCorriente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CuentaCorriente_pkey");

            entity.Property(e => e.InteresMantenimiento).HasPrecision(10, 5);
            entity.Property(e => e.LimiteOperacional).HasPrecision(20, 5);
            entity.Property(e => e.PromedioMensual).HasPrecision(20, 5);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.CuentaCorriente)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CuentaCorriente_CuentaId_fkey");
        });

        modelBuilder.Entity<Movimientos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Movimientos_pkey");

            entity.Property(e => e.CuentaDestino).HasMaxLength(150);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaHora).HasColumnType("timestamp without time zone");
            entity.Property(e => e.MontoTransaccion).HasPrecision(20, 5);
            entity.Property(e => e.TipoOperacion).HasMaxLength(50);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Movimientos_CuentaId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
