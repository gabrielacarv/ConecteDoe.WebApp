using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;

namespace ConecteDoe.WebApp.Models
{
    public class PerfilInstituicaoViewModel
    {
        public Instituicao Instituicao { get; set; }
        public DadosInstituicao DadosInstituicao { get; set; }
        public Endereco Endereco { get; set; }
    }
}
