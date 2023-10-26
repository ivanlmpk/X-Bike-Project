using WebCast.XBike.Entities;
using WebCast.XBike.Interfaces;
using WebCast.XBike.Application.Interfaces;

namespace WebCast.XBike.Application.Services
{
    internal class BicicletaApplicationService : IBicicletaApplicationService
    {
        private IGenericRepository<Bicicleta> _genericRepository;

        public BicicletaApplicationService(IGenericRepository<Bicicleta> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Bicicleta> GetBicicletaById(int id)
        {
           return await _genericRepository.GetByIdAsync(id);
        }

        public async Task AddBicicleta(string nomeModelo, string tamanho, decimal preco)
        {
            var bicicleta = new Bicicleta(nomeModelo, tamanho, preco);

            await _genericRepository.AddAsync(bicicleta);
        }

        public async Task UpdateBicicleta(int id, Bicicleta bicicleta)
        {
            var getBicileta = await _genericRepository.GetByIdAsync(id);

            getBicileta.Cliente = bicicleta.Cliente;
            getBicileta.NomeModelo = bicicleta.NomeModelo;
            getBicileta.Tamanho = bicicleta.Tamanho;
            getBicileta.Cor = bicicleta.Cor;
            getBicileta.Discos = bicicleta.Discos;
            getBicileta.Peso = bicicleta.Peso;
            getBicileta.TemDisponibilidade = bicicleta.TemDisponibilidade;

            await _genericRepository.UpdateAsync(getBicileta);
        }

        public async Task DeleteBicicleta(int id)
        {
            await _genericRepository.DeleteAsync(id);
        }
    } 
}
