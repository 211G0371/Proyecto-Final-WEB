using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class StatsViewModel
    {
        public Estadisticas stasts {  get; set; }
        public List<Jugadores> Jugadores { get; set; }
    }
}
