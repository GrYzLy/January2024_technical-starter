using System.ComponentModel.DataAnnotations;

namespace January2024_technical.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1450, 2100)]
        public int PublicationYear { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Range(0.01, 1000)]
        public decimal Price { get; set; }
    }
}
