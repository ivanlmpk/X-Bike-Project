using WebCast.XBike.Entities;

namespace WebCast.XBike.Application.Interfaces
{
    public interface IBicicletaApplicationService
    {
        Task AddBicicleta(string nomeModelo, string tamanho, decimal preco);
        Task UpdateBicicleta(int id, Bicicleta bicicleta);
        Task DeleteBicicleta(int id);
        Task<Bicicleta> GetBicicletaById(int id);
    }
}
