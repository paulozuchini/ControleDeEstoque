using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoque.API.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }

        public int ClienteID { get; set; }

        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        [StringLength(20)]
        public string StatusPedido { get; set; }
    }
}
