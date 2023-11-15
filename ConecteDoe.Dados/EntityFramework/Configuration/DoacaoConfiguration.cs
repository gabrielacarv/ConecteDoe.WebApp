using ConecteDoe.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.ToTable("Doacao", Constantes.Schema);
            builder.HasKey(d => d.DoacaoId);

            builder
                .Property(d => d.DoacaoId)
                .UseIdentityColumn()
                .HasColumnName("DoacaoId")
                .HasColumnType("int");

            builder
                .Property(d => d.DoadorId)
                .HasColumnName("DoadorId")
                .HasColumnType("int");

            builder
                .Property(d => d.InstituicaoId)
                .HasColumnName("InstituicaoId")
                .HasColumnType("int");

            builder
                .Property(d => d.DataDoacao)
                .HasColumnName("DataDoacao")
                .HasColumnType("date");

            builder
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.DoadorId);

            builder
                .HasOne(u => u.Instituicao)
                .WithMany()
                .HasForeignKey(u => u.InstituicaoId);
        }
    }
}
