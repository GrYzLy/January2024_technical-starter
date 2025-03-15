using System.ComponentModel.DataAnnotations;

namespace January2024_technical.Models
{
    public class Book
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string? Author { get; set; }

        [Range(1000, 9999, ErrorMessage = "Publication Year must be a valid year")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string? Genre { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }
    }
}
