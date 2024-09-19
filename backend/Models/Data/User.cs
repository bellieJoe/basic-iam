using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Data
{
    public record User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("email")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Column("username")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Column("password_hash")]
        [MaxLength(70)]
        public string PasswordHash { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("last_updated_at")]
        public DateTime LastUpdatedAt { get; set; }
    }
}
