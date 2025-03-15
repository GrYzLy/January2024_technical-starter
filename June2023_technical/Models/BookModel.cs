using System;
using System.ComponentModel.DataAnnotations;

namespace June2023_technical.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        [Required]
        public string? Author { get; set; }
        
        [Required]
        [Range(0, 2100)]
        public int PublicationYear { get; set; }
        
        public string? Genre { get; set; }
        
        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }
    }
}