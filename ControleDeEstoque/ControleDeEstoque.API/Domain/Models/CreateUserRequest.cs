using ControleDeEstoque.API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.API.Domain.Models
{
    public class CreateUserRequest
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EnumDataType(typeof(UserRole))]
        public string UserRole { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
