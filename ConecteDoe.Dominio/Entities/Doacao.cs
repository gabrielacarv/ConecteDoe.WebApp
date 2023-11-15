using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConecteDoe.Dominio.Entities
{
    public class Doacao
    {
        public int DoacaoId { get; set; }
        public int DoadorId { get; set; }
        public int InstituicaoId { get; set; }
        public DateTime DataDoacao { get; set; }
        public double Valor { get; set; }
        public Usuario Usuario { get; set; }
        public Instituicao Instituicao { get; set;}
    }
}
