using ProyectoFinal.Models.Entities;

namespace ProyectoFinal.Areas.Admin.Models.ViewModels
{
    public class AgregarImagenSlider
    {
        public Sliders Sliders { get; set; }

        public IFormFile Imagen { get; set; }
    }
}
