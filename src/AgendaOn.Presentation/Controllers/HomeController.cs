using AgendaOn.Domain.Enums;
using AgendaOn.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaOn.Presentation.Controllers
{

    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
                UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
       
            if (UsuarioLogado.TipoUsuario.Equals((int)TipoUsuario.PRESTADOR))
            {
                return RedirectToAction("Agenda", "Agendamento");
            }
            else if (UsuarioLogado.TipoUsuario.Equals((int)TipoUsuario.CLIENTE))
            {
                return RedirectToAction("Prestadores", "Cliente");
            }


            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}