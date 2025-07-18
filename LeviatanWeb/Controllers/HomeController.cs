using System.Diagnostics;
using LeviatanWeb.DAO;
using LeviatanWeb.Models;
using LeviatanWeb.Models.ViewModel;
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

        public IActionResult Gestion()
        {
            var participantes = _dao.ObtenerParticipantes();

            var modeloForm = new List<HomeModel> { new HomeModel() };


            var modelo = new HomeViewModel
            {
                Participantes = participantes,
                formularioEdicion = modeloForm
            };

            return View(modelo);
        }

        public IActionResult addParticipante()
        {
            var modelo = new List<HomeModel> { new HomeModel() };



            return View(modelo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Solicitudes POST

        [HttpPost]
        public IActionResult guardarParticipante(List<HomeModel> participante)
        {

            _dao.IngresarParticipante(participante);

            return RedirectToAction("Sorteo");
        }


        [HttpPost]
        public IActionResult actualizarParticipante(List<HomeModel> participante)
        {

            _dao.ActualizarParticipante(participante);

            return RedirectToAction("Gestion");
        }
    }
}
