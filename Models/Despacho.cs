using System;
using System.Collections.Generic;

namespace CombustiblesGT.Models;

public partial class Despacho
{
    public int IdDespacho { get; set; }

    public DateTime Fecha { get; set; }

    public int IdVehiculo { get; set; }

    public int IdBomba { get; set; }

    public decimal TotalDespachado { get; set; }

    public virtual Bomba IdBombaNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
