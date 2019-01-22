using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net;
using Felpfran.WebApi.NetCore.Repositorios;
using Felpfran.WebApi.NetCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Felpfran.WebApi.NetCore.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        
        // GET: api/clientes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Cliente>))]
        [ProducesResponseType(404)]
        public IActionResult ConsultarTodosClientes()
        {
            var clientes = _clienteRepositorio.ConsultarTodosClientes();

            if (clientes == null)
                return NotFound();

            return Ok(clientes);
        }

        // GET api/clientes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(404)]
        public IActionResult ConsultarClientePorId(long id)
        {
            var cliente = _clienteRepositorio.ConsultarCliente(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST api/clientes
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        public IActionResult CriarCliente([FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _clienteRepositorio.AdicionarCliente(cliente);

            return Ok(cliente);
        }

        // PUT api/clientes/5
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult AtualizarCliente(long id, [FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid || cliente.ID != id)
                return BadRequest();

            var clienteAlterar = _clienteRepositorio.ConsultarCliente(id);

            if (clienteAlterar == null)
                return NotFound();

            clienteAlterar.Nome = cliente.Nome;
            clienteAlterar.Email = cliente.Email;
            clienteAlterar.DataNascimento = cliente.DataNascimento;

            _clienteRepositorio.AtualizarCliente(clienteAlterar);

            return Ok(clienteAlterar);
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(Cliente))]
        [ProducesResponseType(404)]
        public IActionResult ExcluirCliente(long id)
        {
            var clienteExcluir = _clienteRepositorio.ConsultarCliente(id);

            if (clienteExcluir == null)
                return NotFound();

            _clienteRepositorio.ExcluirCliente(id);

            return Ok(clienteExcluir);
        }
    }
}
