using WebCast.XBike.Entities;
using WebCast.XBike.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebCast.XBike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IGenericRepository<Cliente> _repository;

        public ClienteController(IGenericRepository<Cliente> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var clientes = await _repository.GetAllAsync();

            if (clientes == null)
            {
                return NotFound("Nenhum registro encontrado.");
            }
            return Ok(clientes);    
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            await _repository.AddAsync(cliente);
            return CreatedAtRoute("GetCliente", new { id = cliente.Id }, cliente); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id != id)
                return BadRequest();

            var clienteEncontrado = await _repository.GetByIdAsync(id);

            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nome = cliente.Nome;
                clienteEncontrado.Endereco = cliente.Endereco;
                clienteEncontrado.Cidade = cliente.Cidade;
                clienteEncontrado.Profissao = cliente.Profissao;

                await _repository.UpdateAsync(clienteEncontrado);
            } 
            else{ return NotFound(); }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var clienteEncontrado = await _repository.GetByIdAsync(id);

            if(clienteEncontrado != null)
            {
                await _repository.DeleteAsync(id);
            }
            else { return NotFound(); }

            return NoContent();
        }
    }
}
