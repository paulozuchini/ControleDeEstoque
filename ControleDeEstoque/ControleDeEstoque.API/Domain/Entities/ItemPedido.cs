using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Entities
{
    public class ItemPedido
    {
        [Key]
        public int ItemPedidoID { get; set; }

        public int PedidoID { get; set; }

        [ForeignKey("PedidoID")]
        public Pedido Pedido { get; set; }

        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public ItemEstoque ItemEstoque { get; set; }

        public int Quantidade { get; set; }
    }
}
