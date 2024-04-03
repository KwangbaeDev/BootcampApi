using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Documento { get; set; }

    public string? Direccion { get; set; }

    public string? Mail { get; set; }

    public string? Celular { get; set; }

    public string? Estado { get; set; }

    public int BancoId { get; set; }

    public virtual Banco Banco { get; set; } = null!;

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
