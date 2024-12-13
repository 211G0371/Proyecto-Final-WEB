using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models.Entities;
using ProyectoFinal.Models.ViewModels;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Jugadores()
        {
            EsportContext context = new EsportContext();
            var vm = new JugadoresViewModel
            {
                ListaJugadores = context.Jugadores.Select(x => new datos
                {
                    Id = x.Id,
                })
            };
            return View(vm);
        }
        public IActionResult VerJugador(int id)
        {
            EsportContext context = new EsportContext();

            var vm = context.Estadisticas.Include(x => x.IdJugadorNavigation)
                .Where(x => x.IdJugadorNavigation.Id == id).Select(x => new VerJugadorViewModel
                {
                    Id = x.IdJugadorNavigation.Id,
                    Nombre = x.IdJugadorNavigation.Nombre,
                    Gamertag = x.IdJugadorNavigation.Gamertag,
                    Pais = x.IdJugadorNavigation.Pais,
                    Rol = x.IdJugadorNavigation.Rol,
                    Headshot = x.Headshot,
                    Winrate = x.Winrate,
                    Earnings = x.Earnings,
                    KDRatio = x.KDRatio,
                    Lose = x.Lose,
                    Wins = x.Wins,
                }).First();
            return View(vm);
        }
    }
}
