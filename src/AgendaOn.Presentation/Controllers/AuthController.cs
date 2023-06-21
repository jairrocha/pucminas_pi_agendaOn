using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgendaOn.Presentation.ViewModels;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;

        public AuthController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            IUsuarioService usuarioService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> Registrar()
        {
            var registrarUsuario = new RegistrarViewModel();

            return View(registrarUsuario);
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(RegistrarViewModel registrarUsuario)
        {

            if (!ModelState.IsValid)
            {

                return View("Registrar", registrarUsuario);
            }

            
            var user = new IdentityUser
            {
                
                UserName = registrarUsuario.Email,
                Email = registrarUsuario.Email,
                EmailConfirmed = true,
                
            };

            var result = await _userManager.CreateAsync(user, registrarUsuario.Password);

            if (!result.Succeeded) {
                
                var erro = result.Errors.FirstOrDefault()?.Description;

                if (!String.IsNullOrEmpty(erro)) ViewBag.Erro = erro;
                return View();
            }
            
            await _signInManager.SignInAsync(user,false);

            _usuarioService.Cadastrar(TipoUsuario.CLIENTE, registrarUsuario.Name, user.Email, user.Id);
            //_usuarioService.Cadastrar(TipoUsuario.PRESTADOR, registrarUsuario.Name, user.Email, user.Id);


            return RedirectToAction("CarregarInfo");

        }

        public async Task<ActionResult> Autenticar()
        {

            return View(new LoginViewModel());

        }

        [HttpPost]
        public async Task<ActionResult> Autenticar(LoginViewModel loginUsuario)
        {

            if (!ModelState.IsValid)
            {
                return View("Autenticar", loginUsuario);
            }


            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Password, false, true);


           

            if (!result.Succeeded) return View("Autenticar", loginUsuario);


            return RedirectToAction("CarregarInfo");

        }

        public ActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return Redirect("Autenticar");

        }

        [Authorize]
        public ActionResult CarregarInfo()
        {

            var usuarioLogado = _userManager.GetUserAsync(User);

            var cookie = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddHours(60),
            };

            var usuario = _usuarioService.BuscarUsuario(usuarioLogado.Result.Id);

            int idUser = 0;
            int tpUser = 0;
            int idEntity = 0;

            if (usuario?.Cliente != null)
            {
                tpUser = (int)TipoUsuario.CLIENTE;
                idEntity = usuario.Cliente.Id;
                idUser = usuario.Id;
            }
            else if (usuario?.Prestador != null)
            {
                idEntity = usuario.Prestador.Id;
                tpUser = (int)TipoUsuario.PRESTADOR;
                idUser = usuario.Id;
            }
      
            var user = new UsuarioLogadoViewModel()
            {
                IdEntity = idEntity,
                IdUser = idUser,
                TipoUsuario = tpUser,
                
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            Response.Cookies.Append("AgendaOnInfo", $"{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json))}", cookie);
            return RedirectToAction("Index", "Home");



        }



        //[HttpGet("Unauthorized")]
        //public IActionResult NaoAutorizado()
        //{
        //    return View("oi");
        //}

        //[HttpGet("forbidden")]
        //public IActionResult AcessoProibido()
        //{
        //    return Forbid();
        //}



    }
}
