using System;
using System.Collections.Generic;

namespace CombustiblesGT.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public int? IdTipo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Placa { get; set; }

    public int Modelo { get; set; }

    public virtual ICollection<Despacho> Despachos { get; } = new List<Despacho>();

    public virtual TipoCombustible? IdTipoNavigation { get; set; }
}
