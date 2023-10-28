using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Rols
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<MenuRol> MenuRol { get; } = new List<MenuRol>();

    public virtual ICollection<Usuario> Usuario { get; } = new List<Usuario>();
}
