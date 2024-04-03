using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class CajaAhorro
{
    public int Id { get; set; }

    public int CuentaId { get; set; }

    public string? TipoDeposito { get; set; }

    public string? NombreTarjeta { get; set; }

    public string? Estado { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;
}
