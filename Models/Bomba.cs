using System;
using System.Collections.Generic;

namespace CombustiblesGT.Models;

public partial class Bomba
{
    public int IdBomba { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public string? Codigo { get; set; }

    public string? Empresa { get; set; }

    public virtual ICollection<Despacho> Despachos { get; } = new List<Despacho>();
}
