using ConecteDoe.Dominio.Entities;

namespace ConecteDoe.WebApp.Models
{
    public class PesquisaModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
