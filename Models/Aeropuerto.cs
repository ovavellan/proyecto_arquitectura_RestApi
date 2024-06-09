using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaAviacionCivil.Models;

public partial class Aeropuerto
{
    public int IdAeropuerto { get; set; }

    public string? Nombre { get; set; }

    public string? Pais { get; set; }

    public string? Ciudad { get; set; }

    public string? NumHangares { get; set; }

    public int? IdAvion { get; set; }

    [JsonIgnore]

    public virtual ICollection<Hangar> Hangars { get; set; } = new List<Hangar>();

    [JsonIgnore]
    public virtual Aeronave? IdAvionNavigation { get; set; }
}
