using ConecteDoe.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class DadosInstituicaoConfiguration : IEntityTypeConfiguration<DadosInstituicao>
    {
        public void Configure(EntityTypeBuilder<DadosInstituicao> builder)
        {
            builder.ToTable("DadosInstituicao", Constantes.Schema);
            builder.HasKey(d => d.InstituicaoId);

            builder
                .Property(d => d.InstituicaoId)
                .UseIdentityColumn()
                .HasColumnName("InstituicaoId")
                .HasColumnType("int");

            builder
                .Property(d => d.Coordenador)
                .HasColumnName("Coordenador")
                .HasColumnType("varchar(100)");

            builder
                .Property(d => d.Categoria)
                .HasColumnName("Categoria")
                .HasColumnType("varchar(100)");

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
                .HasColumnType("varchar(250)");

            builder
               .Property(d => d.Descricao)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(500)");

            builder
              .Property(d => d.ChavePix)
              .HasColumnName("ChavePix")
              .HasColumnType("varchar(100)");

            builder
                .Property(u => u.Imagem)
                .HasColumnName("Imagem")
                .HasColumnType("varbinary(max)");

            builder
                .HasOne(u => u.Instituicao)
                .WithMany()
                .HasForeignKey(u => u.InstituicaoId);
        }
    }
}
