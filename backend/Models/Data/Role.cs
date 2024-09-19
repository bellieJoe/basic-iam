using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Data
{
    public record Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        [MaxLength(100)]
        public string Value { get; set; }

        [Column("description")]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
