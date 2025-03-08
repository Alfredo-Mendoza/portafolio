using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Models.DTOs;
using Portafolio.Services;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProjects repositoryProjects;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositoryProjects repositoryProjects, IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repositoryProjects = repositoryProjects;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            List<ProyectoDTO> proyectos = repositoryProjects.GetProyects().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            List<ProyectoDTO> Proyectos = repositoryProjects.GetProyects();
            return View(Proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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
