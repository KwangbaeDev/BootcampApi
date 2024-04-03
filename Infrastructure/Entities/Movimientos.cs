using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Movimientos
{
    public int Id { get; set; }

    public string? CuentaDestino { get; set; }

    public string? TipoOperacion { get; set; }

    public decimal? MontoTransaccion { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Estado { get; set; }

    public int CuentaId { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;
}
