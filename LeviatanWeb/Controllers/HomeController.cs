using System.Diagnostics;
using LeviatanWeb.DAO;
using LeviatanWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeviatanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeDAO? _dao;

        public HomeController(ILogger<HomeController> logger,HomeDAO dao)
        {
            _logger = logger;
            _dao = dao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sorteo()
        {
            var participantes = _dao.ObtenerParticipantes();

            return View(participantes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
