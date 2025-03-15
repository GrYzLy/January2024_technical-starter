using January2024_technical.Models;
using Microsoft.EntityFrameworkCore;

namespace January2024_technical.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
