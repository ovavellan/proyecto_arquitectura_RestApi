using System;
using System.Collections.Generic;

namespace SistemaAviacionCivil.Models;

public partial class ProgramaVuelo
{
    public int IdVuelo { get; set; }

    public DateTime? FechaSalida { get; set; }

    public DateTime? HoraSalida { get; set; }

    public int? IdPiloto { get; set; }

    public int? IdAvion { get; set; }

    public string? LugarPartida { get; set; }

    public string? LugarDestino { get; set; }

    public string? TipoVuelo { get; set; }

    public virtual Aeronave? IdAvionNavigation { get; set; }

    public virtual Piloto? IdPilotoNavigation { get; set; }
}
