using System.ComponentModel.DataAnnotations;

namespace January2024_technical.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int PublicatiionYear { get; set; }
        public required string Genre { get; set; }
        public required decimal Price { get; set; }
    }
}
