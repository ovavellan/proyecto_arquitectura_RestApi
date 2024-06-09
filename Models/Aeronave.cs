using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaAviacionCivil.Models;

public partial class Aeronave
{
    public int IdAvion { get; set; }

    public string? Modelo { get; set; }

    public string? CapacidadPasajeros { get; set; }

    public int? IdPiloto { get; set; }

    public string? HorasVuelos { get; set; }

    [JsonIgnore]
    public virtual ICollection<Aeropuerto> Aeropuertos { get; set; } = new List<Aeropuerto>();

    public virtual Piloto? IdPilotoNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProgramaVuelo> ProgramaVuelos { get; set; } = new List<ProgramaVuelo>();
}
