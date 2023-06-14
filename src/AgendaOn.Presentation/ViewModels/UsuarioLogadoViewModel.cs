using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AgendaOn.Presentation.ViewModels
{
    public class UsuarioLogadoViewModel
    {
        public int IdUser { get; set; }
        public int TipoUsuario { get; set; }
        public int IdEntity { get; set; }
        


        private static UsuarioLogadoViewModel _user;
        public static UsuarioLogadoViewModel User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }


    }
}
