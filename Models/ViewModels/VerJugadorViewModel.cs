namespace ProyectoFinal.Models.ViewModels
{
    public class VerJugadorViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Gamertag { get; set; } = null!;

        public string Pais { get; set; } = null!;

        public string Rol { get; set; } = null!;



        public string Headshot { get; set; } = null!;

        public string Winrate { get; set; } = null!;

        public string Wins { get; set; } = null!;

        public string Lose { get; set; } = null!;

        public string KDRatio { get; set; } = null!;

        public string Earnings { get; set; } = null!;
    }
}
