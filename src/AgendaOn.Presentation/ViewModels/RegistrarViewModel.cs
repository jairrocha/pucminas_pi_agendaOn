using AgendaOn.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaOn.Presentation.ViewModels
{
    public class RegistrarViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Campo {0} está em formato inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter no minímo 6 carateres.", MinimumLength = 6)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [PasswordPropertyText]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senha não conferem.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [PasswordPropertyText]
        [Display(Name = "Confirmar Senha")]
        public string ComfirmPassword { get; set; }

    
    }
}
