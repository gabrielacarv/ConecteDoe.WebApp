using ConecteDoe.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class DadosInstituicaoConfiguration : IEntityTypeConfiguration<DadosInstituicao>
    {
        public void Configure(EntityTypeBuilder<DadosInstituicao> builder)
        {
            builder.ToTable("Usuario", Constantes.Schema);
            builder.HasKey(d => d.DadosInstituicaoId);

            builder
                .Property(d => d.DadosInstituicaoId)
                .UseIdentityColumn()
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                .Property(d => d.Coordenador)
                .HasColumnName("Coordenador")
                .HasColumnType("varchar(255)");

            builder
                .Property(d => d.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("date");

            builder
                .Property(d => d.QuantidadeCarentes)
                .HasColumnName("QuantidadeCarentes")
                .HasColumnType("int");

            builder
                .Property(d => d.Causa)
                .HasColumnName("Causa")
                .HasColumnType("varchar");
        }
    }
}
