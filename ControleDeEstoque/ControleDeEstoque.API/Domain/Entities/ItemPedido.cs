using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoque.API.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class ItemPedido
    {
        [Key]
        public int ItemPedidoID { get; set; }

        public int PedidoID { get; set; }

        [ForeignKey("PedidoID")]
        public Pedido Pedido { get; set; }

        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Estoque ItemEstoque { get; set; }

        public int Quantidade { get; set; }
    }
}
