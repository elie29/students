using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Description { get; set; }

        [Required]
        [StringLength(100)]
        public required string Site { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}