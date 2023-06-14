using AgendaOn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOn.Domain.Interfaces.Services
{
    public interface IPrestadorService
    {
        
        Prestador BuscarPrestadorPorId(int id);

        int Cadastrar(Usuario usuario, decimal preco);

    }
}
