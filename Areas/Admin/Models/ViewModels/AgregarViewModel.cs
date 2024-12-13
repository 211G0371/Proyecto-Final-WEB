using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class AgregarViewModel
    {
        public Jugadores Jugadores { get; set; }
        public Estadisticas Estadisticas {  get; set; } 
        public IFormFile Imagen { get; set; }
    }
}
