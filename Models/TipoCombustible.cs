using System;
using System.Collections.Generic;

namespace CombustiblesGT.Models;

public partial class TipoCombustible
{
    public int IdTipo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
