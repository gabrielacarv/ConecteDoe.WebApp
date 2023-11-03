using ConecteDoe.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", Constantes.Schema);
            builder.HasKey(u => u.UsuarioId);

            builder
                .Property(u => u.UsuarioId)
                .UseIdentityColumn()
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                .Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(255)");

            builder
                .Property(u => u.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date");

            builder
                .Property(u => u.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("char(1)");

            builder
                .Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasColumnType("varchar(14)");

            builder
                .Property(u => u.EnderecoId)
                .HasColumnName("EnderecoId")
                .HasColumnType("int");

            builder
                .Property(u => u.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(20)");

            builder
                .Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(255)");

            builder
                .Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(255)");

            //builder.Ignore(u => u.Endereco);

            builder
                .HasOne(u => u.Endereco)
                .WithMany()
                .HasForeignKey(u => u.EnderecoId);
        }
    }
}
