using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Equipo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;
}
