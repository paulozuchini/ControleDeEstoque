using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ControleDeEstoque.API.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public UserRole UserRole { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
