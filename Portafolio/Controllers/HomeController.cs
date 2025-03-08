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

        public HomeController(ILogger<HomeController> logger, IRepositoryProjects repositoryProjects)
        {
            _logger = logger;
            this.repositoryProjects = repositoryProjects;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
