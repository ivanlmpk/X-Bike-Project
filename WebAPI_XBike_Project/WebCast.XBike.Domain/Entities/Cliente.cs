using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Profissao { get; set; }
        // Bom inicializar a coleção para evitar erros de nullreference 
        // no caso se não inicializarmos a coleção aqui e formos fazer:
        // Dono dono = new dono;
        // dono.Bicicletas.add(new Bicicleta()) -- iria disparar um erro de nullreference pois a lista de bicicletas nao foi inicializada
        public List<Bicicleta> Bicicletas { get; set; } = new List<Bicicleta>();

        public void SetNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do cliente inválido.");

            Nome = nome;
        }
    }
}
