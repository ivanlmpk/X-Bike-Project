using ASP.NET_WebApi_Marcoratti.Controllers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace WebAPi.xUnitTests
{
    public class BicicletaTest
    {
        [Fact]
        public void GetBicicleta_Teste()
        {
            // Arrange
            var mockRepo = new Mock<IGenericRepository<Bicicleta>>();
            var bicicletaFake = new Bicicleta("Triban rc150", "XL", 2500) { Id = 1, Cor = "Branca", TemDisponibilidade = true };

            mockRepo.Setup(mockRepo => mockRepo.GetByIdAsync(1)).ReturnsAsync(bicicletaFake);

            // Aqui estamos fornecendo a versão mockada em vez da implementação real
            var bicicletaController = new BicicletaController(mockRepo.Object);

            // Act
            var result = bicicletaController.GetById(1);

            // Como provavelmente retorna um IActionResult, precisamos pegar o valor do resultado
            // Tenta converter o resultado para um OkObjectResult
            var okResult = result.Result as OkObjectResult;

            if (okResult == null)
            {
                Assert.True(false, "Método não retornou um OkObjectResult.");
                return;
            }

            var bicicletaRetornada = okResult?.Value as Bicicleta;

            if (bicicletaRetornada == null)
            {
                Assert.True(false, "O valor retornado não é uma Bicicleta.");
                return;
            }

            // Assert
            Assert.NotNull(bicicletaRetornada);
            Assert.Equal("Triban rc150", bicicletaRetornada?.NomeModelo);
        }
    }
}
