using ConecteDoe.Dominio.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco", Constantes.Schema);
            builder.HasKey(e => e.EnderecoId);

            builder
                .Property(e => e.EnderecoId)
                .UseIdentityColumn()
                .HasColumnName("EnderecoId")
                .HasColumnType("int");

            builder
                .Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(255)");

            builder
                .Property(e => e.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar(10)");

            builder
                .Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasColumnType("int");

            builder
                .Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(50)");
        }
    }
}