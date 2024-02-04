using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Entities
{
    public class Faturamento
    {
        [Key]
        public int FaturamentoID { get; set; }

        public int PedidoID { get; set; }

        [ForeignKey("PedidoID")]
        public Pedido Pedido { get; set; }

        public DateTime DataFaturamento { get; set; }

        [StringLength(255)]
        public string Observacao { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
