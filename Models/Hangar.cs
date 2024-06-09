using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaAviacionCivil.Models;

public partial class Hangar
{
    public int IdHangar { get; set; }

    public string? CapacidadAeronaves { get; set; }

    public string? TipoAeronaves { get; set; }

    public int? IdAeropuerto { get; set; }

    [JsonIgnore]
    public virtual Aeropuerto? IdAeropuertoNavigation { get; set; }
}
