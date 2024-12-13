using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models.Entities;

public partial class Estadisticas
{
    public int Id { get; set; }

    public string Headshot { get; set; } = null!;

    public string Winrate { get; set; } = null!;

    public string Wins { get; set; } = null!;

    public string Lose { get; set; } = null!;

    public string KDRatio { get; set; } = null!;

    public string Earnings { get; set; } = null!;

    public int IdJugador { get; set; }

    public virtual Jugadores IdJugadorNavigation { get; set; } = null!;
}
