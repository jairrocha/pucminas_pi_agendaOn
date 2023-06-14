﻿using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Services;
using AgendaOn.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOn.Presentation.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {

        private readonly IClienteService clienteService;
        


        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        public IActionResult Prestadores()
        {
            if (UsuarioLogado.TipoUsuario == (int)TipoUsuario.PRESTADOR)
            {
                return RedirectToAction("Agenda", "Agendamento");
            }

            var vw = new PrestadoresViewModel()
            {
                Prestadores = clienteService.ListarPrestadores(),
            };

            return View(vw);
        }

   

    }
}
