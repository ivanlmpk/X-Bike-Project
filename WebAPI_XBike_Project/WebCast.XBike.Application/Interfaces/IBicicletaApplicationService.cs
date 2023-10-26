using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
