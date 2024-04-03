using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Cuenta
{
    public int Id { get; set; }

    public string? Titular { get; set; }

    public string? NumeroCuenta { get; set; }

    public string? Tipo { get; set; }

    public decimal Saldo { get; set; }

    public int ClienteId { get; set; }

    public virtual ICollection<CajaAhorro> CajaAhorro { get; set; } = new List<CajaAhorro>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<CuentaCorriente> CuentaCorriente { get; set; } = new List<CuentaCorriente>();

    public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();
}
