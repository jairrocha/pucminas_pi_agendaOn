using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AgendaOn.Presentation.ViewModels
{
    public class AgendamentoViewModel
    {
        public int ClienteId { get; set; }
        public int PrestadorId { get; set; }

        [Required (ErrorMessage = "Escolha uma data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Selecione um horário")]
        public int? SelectedOptionId { get; set; }
        public int AgendametoId { get; set; }

    }
}
