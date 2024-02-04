using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }
    }
}
