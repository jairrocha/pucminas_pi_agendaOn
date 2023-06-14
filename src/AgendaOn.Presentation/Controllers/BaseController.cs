using AgendaOn.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOn.Presentation.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected UsuarioLogadoViewModel UsuarioLogado
        {
            get
            {
                try
                {
                    var cookie = Request.Cookies["AgendaOnInfo"];
                    string json = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(cookie));
                    var usuarioLogado = Newtonsoft.Json.JsonConvert.DeserializeObject<UsuarioLogadoViewModel>(json);
                    UsuarioLogadoViewModel.User = usuarioLogado;
                    return usuarioLogado;


                }

                catch (Exception)
                {
                    return null;
                }
            }

        }

       

        
           
    }
}
