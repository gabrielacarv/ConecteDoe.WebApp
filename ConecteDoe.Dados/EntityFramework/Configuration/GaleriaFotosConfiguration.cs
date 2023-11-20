using ConecteDoe.Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dados.EntityFramework.Configuration
{
    public class GaleriaFotosConfiguration : IEntityTypeConfiguration<GaleriaFotos>
    {
        public void Configure(EntityTypeBuilder<GaleriaFotos> builder)
        {
            builder.ToTable("GaleriaFotos", Constantes.Schema);
            builder.HasKey(d => d.InstituicaoId);

            builder
                .Property(d => d.InstituicaoId)
                .UseIdentityColumn()
                .HasColumnName("InstituicaoID")
                .HasColumnType("int");

            builder
                .Property(u => u.Imagem)
                .HasColumnName("Imagem")
                .HasColumnType("varbinary(max)");
        }
    }
}