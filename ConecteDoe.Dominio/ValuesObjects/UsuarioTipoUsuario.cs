using ConecteDoe.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dominio.ValuesObjects
{
    public class UsuarioTipoUsuario
    {
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Instituicao instituicao { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}