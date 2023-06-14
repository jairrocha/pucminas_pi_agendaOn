using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;
using AgendaOn.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOn.Presentation.Controllers
{
    [Authorize]
    public class AgendamentoController : BaseController
    {
        private readonly IAgendamentoService _agendamentoService;



        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;

        }

        [HttpPost]
        public IActionResult Agendar(AgendamentoViewModel vw)
        {
            if (!ModelState.IsValid)
            {
                return View("Agendar", vw);
            }

            if (vw.AgendametoId > 0)
            {
                _agendamentoService.Alterar(vw.AgendametoId, (int)vw.SelectedOptionId, vw.Data);
            }
            else
            { 
                _agendamentoService.Agendar(vw.ClienteId, vw.PrestadorId, (int)vw.SelectedOptionId, vw.Data);
            }

            return RedirectToAction("Agenda", "Agendamento");
        }


        [HttpGet]
        public IActionResult Agenda()
        {

            var vw = new AgendaViewModel();

            if (UsuarioLogado.TipoUsuario == (int)TipoUsuario.CLIENTE)
            {
                var result = _agendamentoService.BuscarProximosAgendamentosCliente(UsuarioLogado.IdEntity).ToList();
                vw.Agendamentos = result;

            }
            else if (UsuarioLogado.TipoUsuario == (int)TipoUsuario.PRESTADOR)
            {
                var result = _agendamentoService.BuscarProximosAgendamentosPrestador(UsuarioLogado.IdEntity).ToList();
                vw.Agendamentos = result;
            }

            return View(vw);
        }

        public IActionResult Agendar(int id, int idAleracao = 0)
        {

            if (UsuarioLogado.TipoUsuario == (int)TipoUsuario.PRESTADOR)
            {
                return RedirectToAction("Agenda", "Agendamento");
            }

            var vw = new AgendamentoViewModel()
            {
                ClienteId = UsuarioLogado.IdEntity,
                Data = DateTime.Now.Date,
                PrestadorId = id
            };

            if (idAleracao > 0)
            {
                vw.AgendametoId = idAleracao;
            }

            return View(vw);
        }

        [HttpPost]
        public IActionResult CarregarHorariosDisponiveis(int prestadorId, DateTime data)
        {

            var horarios = _agendamentoService.BuscarHorariosDisponiveisPrestador(prestadorId, data);

            var weekDay = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
                        
            if (weekDay.Contains(data.Date.DayOfWeek))
            {
                return Json(null);
            }
            else if (data.Date == DateTime.Now.Date)
            {

                var resp = horarios
                    .Where(_ => _.HoraInicio.Hour >= DateTime.Now.Hour &&
                           new TimeSpan((int)DateTime.Now.Hour, (int)DateTime.Now.Minute, 0) <=
                           new TimeSpan(_.HoraFim.Hour, _.HoraFim.Minute, 0))

                    .Select(_ => new { Id = _.Id, Horario = $"{_.HoraInicio}-{_.HoraFim}" })
                    .ToList();

                return Json(resp);

            }
            else if (data.Date > DateTime.Now.Date)
            {

                var resp = horarios
                    .Select(_ => new { Id = _.Id, Horario = $"{_.HoraInicio}-{_.HoraFim}" })
                    .ToList();

                return Json(resp);

            }


            return Json(null);

        }

        public IActionResult Cancelar(int id)
        {
            _agendamentoService.Cancelar(id);

            return RedirectToAction("Agenda", id);
        }

        
    }
}
