using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class InstituicaoConfiguration : IEntityTypeConfiguration<Instituicao>
    {
        public void Configure(EntityTypeBuilder<Instituicao> builder)
        {
            builder.ToTable("Instituicao", Constantes.Schema);
            builder.HasKey(i => i.InstituicaoId);

            builder
                .Property(i => i.InstituicaoId)
                .UseIdentityColumn()
                .HasColumnName("InstituicaoId")
                .HasColumnType("int");

            builder
                .Property(i => i.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasColumnType("varchar(255)");

            builder
                .Property(i => i.CNPJ)
                .HasColumnName("CNPJ")
                .HasColumnType("varchar(18)");
          
            builder
                .Property(i => i.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(11)");

            builder
                .Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(255)");

            builder
                .Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(255)");

            builder
                .Property(i => i.EnderecoId)
                .HasColumnName("EnderecoId")
                .HasColumnType("int");

            builder
               .Property(u => u.Imagem)
               .HasColumnName("Imagem")
               .HasColumnType("varbinary(max)");

            builder
                .HasOne(u => u.Endereco)
                .WithMany()
                .HasForeignKey(u => u.EnderecoId);
        }
    }
}
