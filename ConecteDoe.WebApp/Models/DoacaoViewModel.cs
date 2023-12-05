using ConecteDoe.Dominio.Entities;

namespace ConecteDoe.WebApp.Models
{
    public class DoacaoViewModel
    {
        public IEnumerable<Doacao> DoacoesDaInstituicao { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
