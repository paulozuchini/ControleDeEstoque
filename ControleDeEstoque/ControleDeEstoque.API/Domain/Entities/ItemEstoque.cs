using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Entities
{
    public class ItemEstoque
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }
    }

}
