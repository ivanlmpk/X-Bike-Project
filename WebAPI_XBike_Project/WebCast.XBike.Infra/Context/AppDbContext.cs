using Microsoft.EntityFrameworkCore;
using WebCast.XBike.Entities;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Bicicleta> Bicicletas { get; set; }   
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento para a entidade Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id); // Define a chave primária

            // Eu comentei o mapeamento das outras props, pois só precisamos mapear o Id que o EF faz os outros mapeamentos de forma automatica.
            // No caso as props de string, por exemplo, vao ser mapeadas como nvarchar(max)
            // As relaçoes também são feitas de forma automatica pelo EF (precisamos da chave estrangeira na Bicicleta)
            //----------------------------------------------------------------------------------------------------------

            //modelBuilder.Entity<Cliente>()
            //    .Property(c => c.Nome) // Define a propriedade Nome
            //    .IsRequired(); // Torna a propriedade obrigatória

            //modelBuilder.Entity<Cliente>().Property(c => c.Idade);

            //modelBuilder.Entity<Cliente>().Property(c => c.Endereco).HasMaxLength(100);
            //modelBuilder.Entity<Cliente>().Property(x => x.Cidade).HasMaxLength(50);
            //modelBuilder.Entity<Cliente>().Property(x => x.Profissao).HasMaxLength(50);

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(c => c.Bicicletas) // Define a relação de um para muitos (um Cliente possui várias Bicicletas)
            //    .WithOne(b => b.Cliente);
            //.HasForeignKey(b => b.ClienteId); // Define a chave estrangeira

            //----------------------------------------------------------------------------------------------------------
            // Mapeamento para a entidade Bicleta
            modelBuilder.Entity<Bicicleta>().HasKey(b => b.Id);

            //modelBuilder.Entity<Bicicleta>().Property(x => x.NomeModelo).HasMaxLength(128).IsRequired();
            //modelBuilder.Entity<Bicicleta>().Property(x => x.Tamanho).HasMaxLength(10);
            //modelBuilder.Entity<Bicicleta>().Property(x => x.Cor).HasMaxLength(20);
            //modelBuilder.Entity<Bicicleta>().Property(x => x.Preco);
            //modelBuilder.Entity<Bicicleta>().Property(x => x.Peso);
            //modelBuilder.Entity<Bicicleta>().Property(x => x.Discos);
            //modelBuilder.Entity<Bicicleta>()
            //    .HasOne(b => b.Cliente) // Indica que uma Bicicleta tem um Cliente
            //    .WithMany(c => c.Bicicletas); // Indica que um Cliente tem várias Bicicletas
            //.HasForeignKey(b => b.ClienteId); // Define a chave estrangeira
        }
    }
}
