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
    public class UsuarioTipoUsuarioConfiguration : IEntityTypeConfiguration<UsuarioTipoUsuario>
    {
        public void Configure(EntityTypeBuilder<UsuarioTipoUsuario> builder)
        {
            builder.ToTable("UsuarioTipoUsuario", Constantes.Schema);
        
            // Define uma chave composta (UsuarioId, TipoUsuarioId)
            builder.HasKey(u => new { u.UsuarioId, u.TipoUsuarioId });

            builder
                .Property(u => u.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnType("int");

            builder
                .Property(u => u.TipoUsuarioId)
                .HasColumnName("TipoUsuarioId")
                .HasColumnType("int");

            builder
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            builder
                .HasOne(u => u.TipoUsuario)
                .WithMany()
                .HasForeignKey(u => u.TipoUsuarioId);
        }
    }
}
