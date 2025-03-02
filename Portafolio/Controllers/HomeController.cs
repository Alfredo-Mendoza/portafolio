using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Models.DTOs;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProyectoDTO> proyectos = GetProyects().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        private List<ProyectoDTO> GetProyects()
        {
            return new List<ProyectoDTO>() { 
                new ProyectoDTO {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.Net Core",
                    Link = "https://www.amazon.com.mx",
                    ImagenURL = "/imagenes/amazon.png"
                },
                new ProyectoDTO {
                    Titulo = "New York Times",
                    Descripcion = "Páginas de noticias en React",
                    Link = "https://www.nytimes.com",
                    ImagenURL = "/imagenes/nyt.png"
                },
                new ProyectoDTO {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://www.reddit.com",
                    ImagenURL = "/imagenes/reddit.png"
                },
                new ProyectoDTO {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para comprar vídeojeugos",
                    Link = "www.steam.com",
                    ImagenURL = "/imagenes/steam.png"
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
