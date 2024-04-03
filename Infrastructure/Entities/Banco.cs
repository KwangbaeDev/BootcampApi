using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Banco
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Mail { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
}
