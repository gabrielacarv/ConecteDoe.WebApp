using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConecteDoe.Dominio.ValuesObjects;

namespace ConecteDoe.Dominio.Entities
{
    public class Instituicao
    {
        public int InstituicaoId { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int EnderecoId { get; set; }
        public byte[] Imagem { get; set; }
        public DadosInstituicao DadosInstituicao { get; set; }
    }
}