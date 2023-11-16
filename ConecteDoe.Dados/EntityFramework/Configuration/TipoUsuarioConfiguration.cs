using ConecteDoe.Dominio.Entities;
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
    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TipoUsuario", Constantes.Schema);

            builder.HasKey(u => u.TipoUsuarioId);

            builder
                .Property(u => u.TipoUsuarioId)
                .HasColumnName("TipoUsuarioId")
                .HasColumnType("int");

            builder
                .Property(u => u.NomeTipo)
                .HasColumnName("NomeTipo")
                .HasColumnType("string");
        }
    }
}
