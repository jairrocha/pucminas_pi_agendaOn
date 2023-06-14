using AgendaOn.Domain.Entities;
using System.Data;
using System.Reflection;

namespace AgendaOn.Presentation.ViewModels
{
    public class AgendaViewModel
    {
        public IEnumerable<Agendamento> Agendamentos { get; set; }
        public int TipoUsuario { get; set; }

        public AgendaViewModel()
        {
            Agendamentos = new List<Agendamento>();
            TipoUsuario =  UsuarioLogadoViewModel.User.TipoUsuario;
        }

    }
}
