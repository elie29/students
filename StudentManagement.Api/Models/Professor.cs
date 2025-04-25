using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public required string CourseTitle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}