namespace Repositories.Model
{
    public class PedidoDetalhadoModel
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public int StatusId { get; set; }
        public string StatusDescricao { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Apagado { get; set; }
    }
}
