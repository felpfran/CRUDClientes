using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Felpfran.WebApi.NetCore.Models;

namespace Felpfran.WebApi.NetCore.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Context _context;

        public ClienteRepositorio(Context ctx)
        {
            _context = ctx;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public Cliente ConsultarCliente(long id)
        {
            return _context.Clientes.Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<Cliente> ConsultarTodosClientes()
        {
            return _context.Clientes.ToList();
        }

        public void ExcluirCliente(long id)
        {
            var clienteExcluir = _context.Clientes.First(x => x.ID == id);
            _context.Clientes.Remove(clienteExcluir);
            _context.SaveChanges();
        }
    }
}
