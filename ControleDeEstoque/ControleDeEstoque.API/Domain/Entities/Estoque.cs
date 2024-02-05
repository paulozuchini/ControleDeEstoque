using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoque.API.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Estoque
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }
    }

}
