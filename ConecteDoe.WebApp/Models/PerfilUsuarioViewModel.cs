using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;

namespace ConecteDoe.WebApp.Models
{
    public class PerfilUsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
