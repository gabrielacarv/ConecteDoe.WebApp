namespace ConecteDoe.Dominio.Entities
{
    public class DadosInstituicao
    {
        public int InstituicaoId { get; set; }
        public string Coordenador { get; set; }
        public string Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeCarentes { get; set; }
        public string Causa { get; set; }
        public string Descricao { get; set; }
        public string ChavePix { get; set; }
        public Instituicao Instituicao { get; set; }
        public byte[] Imagem { get; set; }
    }
}