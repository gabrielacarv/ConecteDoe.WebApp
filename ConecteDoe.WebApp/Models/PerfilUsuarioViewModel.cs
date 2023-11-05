using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;

namespace ConecteDoe.WebApp.Models
{
    public class PerfilUsuarioViewModel
    {
        public required Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
