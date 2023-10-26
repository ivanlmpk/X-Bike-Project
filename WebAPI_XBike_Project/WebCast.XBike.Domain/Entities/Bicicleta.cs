using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Bicicleta
    {
        public int Id { get; set; }
        public string NomeModelo { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public Double Peso { get; set; }
        public bool Discos { get; set; }
        public bool TemDisponibilidade { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Eu posso criar outro construtor dependendo do contexto
        public Bicicleta(string nomeModelo, string tamanho, decimal preco)
        {
            SetBicicleta(nomeModelo, tamanho, preco);
        }

        public void SetBicicleta(string nomeModelo, string tamanho, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nomeModelo))
                throw new Exception("Nome do modelo inválido.");

            NomeModelo = nomeModelo;

            if (string.IsNullOrWhiteSpace(tamanho))
            {
                throw new Exception("Tamanho inválido.");

            } else { 

                var tamanhosBike = new[] { "XS", "S", "M", "L", "XL" };

                for (int i = 0; i < tamanhosBike.Length; i++)
                {
                    if (tamanho == tamanhosBike[i])
                    {
                        Tamanho = tamanho;
                    } 
                }

                if ( Tamanho == null) 
                    throw new Exception("Tamanho inválido.");

            }

            if (preco <= 0 || preco >= 99999)
                throw new Exception("Preço de bicicleta inválido.");

            Preco = preco;
        }
    }
}
