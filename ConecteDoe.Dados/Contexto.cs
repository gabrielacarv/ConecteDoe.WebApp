using ConecteDoe.Dados.EntityFramework.Configuration;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace ConecteDoe.Dados
{
    public class Contexto : DbContext
    {   
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Doacao> Doacao { get; set; }
        public DbSet<DadosInstituicao> DadosInstituicao { get; set; }
        public DbSet<UsuarioTipoUsuario> UsuarioTipoUsuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<GaleriaFotos> GaleriaFotos { get; set; }

        public Contexto() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = 201.62.57.93, 1434; 
                                    Database = BD044323; 
                                    User ID = RA044323; 
                                    Password = 044323;
                                    TrustServerCertificate=true"
            );
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server = conectedoedb.database.windows.net; database = ConecteDoeDB; user = conectedoedb; password = ConecteDoe@; trustServerCertificate = true"
        //    );
        //}10.107.176.41,1434

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new InstituicaoConfiguration());
            modelBuilder.ApplyConfiguration(new DadosInstituicaoConfiguration());
            modelBuilder.ApplyConfiguration(new DoacaoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioTipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new GaleriaFotosConfiguration());
        }
    }
}
