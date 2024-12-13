using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoFinal.Models.ViewModels
{
    public class JugadoresViewModel
    {
        public IEnumerable<datos> ListaJugadores { get; set; }
    }

    public class datos
    {
        public int Id { get; set; }
    }
}
