using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ProgramacionWeb.Reposiory;
using ProyectoFinal.Areas.Admin.Models.ViewModels;
using ProyectoFinal.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        EsportContext context;
        Repository<Jugadores> jugadorRepository;
        Repository<Sliders> SliderRepository;
        Repository<Estadisticas> estadisticasRepository;
        public HomeController()
        {
            context = new EsportContext();
            jugadorRepository = new(context);
            SliderRepository = new(context);
            estadisticasRepository = new(context);

        }

        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }





        /// <summary>
        /// ////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AgregarJugadordex()
        {

            return View();
   
        }
        [HttpPost]
        public IActionResult AgregarJugadordex(AgregarViewModel vm)
        {

            ModelState.Clear();
            if (vm.Imagen == null)
            {
                ModelState.AddModelError("", "Debes de seleccinar la imagen del jugador");
            }
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Nombre))
            {
                ModelState.AddModelError("", "EL *Nombre* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Gamertag))
            {
                ModelState.AddModelError("", "EL *Gamertag* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Rol))
            {
                ModelState.AddModelError("", "EL *Rol* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Pais))
            {
                ModelState.AddModelError("", "EL *Pais* ES INCORRECTO");
            }
            if (ModelState.IsValid)
            {
                jugadorRepository.Insert(vm.Jugadores);



                var ruta = $"wwwroot/Imagenes/Jugadores/{vm.Jugadores.Id}.png";
                if (vm.Imagen != null)
                {
                    FileStream fs = System.IO.File.Create(ruta);
                    vm.Imagen.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }

        }
        ////////////////////////////////////////

        public IActionResult Admjugadores()
        {
            var datos = jugadorRepository.GetAll();
            return View(datos);
        }





        /// <summary>
        /// ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EliminarJugador(int id)
        {
            var datos = jugadorRepository.Get(id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            return View(datos);
        }
        [HttpPost]
        public IActionResult EliminarJugador(Jugadores vm)
        {
            var datos = jugadorRepository.Get(vm.Id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }

            jugadorRepository.Delete(datos);

            var ruta = $"wwwroot/Imagenes/Jugadores/{vm.Id}.png";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("Index");
        }





        ///////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditarJugador(int id)
        {
            var datos = jugadorRepository.Get(id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }

            // Crear un AgregarViewModel con el jugador
            var viewModel = new AgregarViewModel
            {
                Jugadores = datos
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditarJugador(AgregarViewModel vm)
        {
            ModelState.Clear();

            if (string.IsNullOrWhiteSpace(vm.Jugadores.Nombre))
            {
                ModelState.AddModelError("", "EL *Nombre* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Gamertag))
            {
                ModelState.AddModelError("", "EL *Gamertag* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Rol))
            {
                ModelState.AddModelError("", "EL *Rol* ES INCORRECTO");
            }
            if (string.IsNullOrWhiteSpace(vm.Jugadores.Pais))
            {
                ModelState.AddModelError("", "EL *Pais* ES INCORRECTO");
            }
            if (ModelState.IsValid)
            {

                var datos = jugadorRepository.Get(vm.Jugadores.Id);
                if (datos == null)
                {
                    return RedirectToAction("Index");
                }
                datos.Nombre = vm.Jugadores.Nombre;
                datos.Gamertag = vm.Jugadores.Gamertag;
                datos.Rol = vm.Jugadores.Rol;
                datos.Pais = vm.Jugadores.Pais;


                var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Imagenes", "Jugadores", $"{vm.Jugadores.Id}.png");
                if (vm.Imagen != null)
                {
                    FileStream fs = System.IO.File.Create(ruta);
                    vm.Imagen.CopyTo(fs);
                    fs.Close();
                }
                jugadorRepository.Update(datos);
                return RedirectToAction("Index");

            }
            return View(vm);

        }





        /// <summary>
        /// ////
        /// </summary>
        /// <returns></returns>
        public IActionResult AdmCambiarIndex()
        {
            var datos = SliderRepository.GetAll();
            return View(datos);
        }
        ///////////////////


        [HttpGet]
        public IActionResult AgregarImagenIndex()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AgregarImagenIndex(AgregarImagenSlider vm)
        {
            ModelState.Clear();

            if (vm.Imagen == null)
            {
                ModelState.AddModelError("", "Debes de seleccionar la imagen de la propiedad");
            }

            if (ModelState.IsValid)
            {
                var nuevoSlider = new Sliders
                {
                    NombreDelSlider = vm.Sliders.NombreDelSlider,

                };


                SliderRepository.Insert(nuevoSlider);
                var ruta = $"wwwroot/Imagenes/ImagenesSlider/{nuevoSlider.NombreDelSlider}.png";
                if (vm.Imagen != null)
                {
                    using (var fs = System.IO.File.Create(ruta))
                    {
                        vm.Imagen.CopyTo(fs);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }




        public IActionResult EliminarImagen(Sliders vm)
        {
            var xd = SliderRepository.Get(vm.Id);

            SliderRepository.Delete(xd);
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Imagenes", "Jugadores", $"{xd.Id}.png");  ///// error
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("AdmCambiarIndex");
        }


        [HttpGet]
        public IActionResult AgregarEstadisticas(int id)
        {
            var datos = jugadorRepository.Get(id);
            
            AgregarViewModel vm = new()
            {
               Jugadores=datos
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult AgregarEstadisticas(AgregarViewModel vm)
        {
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(vm.Estadisticas.Headshot))
            {
                ModelState.AddModelError("", "El *Headshot* es incorrecto.");
            }

            if (string.IsNullOrWhiteSpace(vm.Estadisticas.Winrate))
            {
                ModelState.AddModelError("", "El *Winrate* es incorrecto.");
            }

            if (string.IsNullOrWhiteSpace(vm.Estadisticas.KDRatio))
            {
                ModelState.AddModelError("", "El *KDRatio* es incorrecto.");
            }

            if (string.IsNullOrWhiteSpace(vm.Estadisticas.Earnings))
            {
                ModelState.AddModelError("", "El *Earnings* es incorrecto.");
            }

            if (string.IsNullOrWhiteSpace(vm.Estadisticas.Lose))
            {
                ModelState.AddModelError("", "El *Lose* es incorrecto.");
            }
            if (string.IsNullOrWhiteSpace(vm.Estadisticas.Wins))
            {
                ModelState.AddModelError("", "El *Wins* es incorrecto.");
            }
            if (ModelState.IsValid)
            {
                var jugador = jugadorRepository.Get(vm.Jugadores.Id);
                vm.Estadisticas.IdJugador = jugador.Id;

                estadisticasRepository.Insert(vm.Estadisticas);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }







    }
}
