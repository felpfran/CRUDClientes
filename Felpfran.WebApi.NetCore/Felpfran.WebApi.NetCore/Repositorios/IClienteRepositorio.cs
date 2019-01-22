using Felpfran.WebApi.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Felpfran.WebApi.NetCore.Repositorios
{
    public interface IClienteRepositorio
    {
        void AdicionarCliente(Cliente cliente);

        IEnumerable<Cliente> ConsultarTodosClientes();

        Cliente ConsultarCliente(long id);

        void ExcluirCliente(long id);

        void AtualizarCliente(Cliente cliente);
    }
}
