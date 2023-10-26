using WebCast.XBike.Entities;
using WebCast.XBike.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebCast.XBike.Application.Interfaces;

namespace WebCast.XBike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletaController : ControllerBase
    {
        // Injeção do repositório
        private readonly IGenericRepository<Bicicleta> _repository;
        private readonly IBicicletaApplicationService _bicicletaApplicationService;

        public BicicletaController(IGenericRepository<Bicicleta> repository)
        {
            _repository = repository;
        }

        public BicicletaController(IGenericRepository<Bicicleta> repository, IBicicletaApplicationService bicicletaApplicationService)
        {
            _repository = repository;
            _bicicletaApplicationService = bicicletaApplicationService;
        }

        // End-points
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bicicletas = await _repository.GetAllAsync();

            if (bicicletas == null)
            {
                return NotFound("Nenhum registro encontrado.");
            }
            return Ok(bicicletas);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bicicleta = await _repository.GetByIdAsync(id);

            if (bicicleta == null)
            {
                return NotFound("Bicicleta não encontrada."); 
            }
            return Ok(bicicleta);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBicicleta([FromBody] Bicicleta bicicleta)
        {
            if (bicicleta == null)
                return BadRequest();

            await _bicicletaApplicationService.AddBicicleta(bicicleta.NomeModelo, bicicleta.Tamanho, bicicleta.Preco);
            return CreatedAtRoute("GetBicicleta", new { id = bicicleta.Id }, bicicleta);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBicicleta(int id, [FromBody] Bicicleta bicicleta)
        {
            var bicicletaEncontrada = await _bicicletaApplicationService.GetBicicletaById(id);

            if (bicicletaEncontrada != null)
            {
                await _bicicletaApplicationService.UpdateBicicleta(id, bicicleta);
            } else { return NotFound(); }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicicleta(int id)
        {
            var bicicletaEncontrada = await _repository.GetByIdAsync(id);

            if (bicicletaEncontrada != null)
            {
                await _repository.DeleteAsync(id);
            }
            else { return NotFound(); }

            return NoContent();
        }
    }
}
