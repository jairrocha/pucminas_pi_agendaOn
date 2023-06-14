using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOn.Presentation.Controllers
{
    [Authorize]
    public class AgendaController : BaseController
    {

        public IActionResult Index()
        {



            return View();
        }
    }
}
