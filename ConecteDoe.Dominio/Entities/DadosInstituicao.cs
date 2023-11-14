﻿namespace ConecteDoe.Dominio.Entities
{
    public class DadosInstituicao
    {
        public int DadosInstituicaoId { get; set; }
        public string Coordenador { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeCarentes { get; set; }
        public string Causa { get; set; }
        public Instituicao Instituicao { get; set; }
        public int InstituicaoId { get; set; }
        public byte[] Imagem { get; set; }
    }
}