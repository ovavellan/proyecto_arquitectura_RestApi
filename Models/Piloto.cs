using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaAviacionCivil.Models;

public partial class Piloto
{
    public int IdPiloto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNac { get; set; }

    public DateTime? FechaEmisLicen { get; set; }

    public string? TipoLicencia { get; set; }

    [JsonIgnore]

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
    [JsonIgnore]
    public virtual ICollection<ProgramaVuelo> ProgramaVuelos { get; set; } = new List<ProgramaVuelo>();
}
