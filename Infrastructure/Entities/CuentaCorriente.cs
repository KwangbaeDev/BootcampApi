using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class CuentaCorriente
{
    public int Id { get; set; }

    public int CuentaId { get; set; }

    public decimal? LimiteOperacional { get; set; }

    public decimal? PromedioMensual { get; set; }

    public decimal? InteresMantenimiento { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;
}
