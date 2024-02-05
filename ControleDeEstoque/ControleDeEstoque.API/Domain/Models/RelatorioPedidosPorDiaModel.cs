namespace ControleDeEstoque.API.Domain.Models
{
    public class RelatorioPedidosPorDiaModel
    {
        public DateTime DataPedido { get; set; }
        public int ClienteID { get; set; }
        public string NomeCliente { get; set; }
        public int PedidoID { get; set; }
        public string StatusPedido { get; set; }
        public int ItemID { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
