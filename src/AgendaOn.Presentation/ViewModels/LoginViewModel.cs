using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaOn.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Campo {0} está em formato inválido")]
        [DisplayName("E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("Senha:")]
        public string Password { get; set; }
    }
}
