using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Jugadores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Gamertag { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Estadisticas> Estadisticas { get; set; } = new List<Estadisticas>();
}
