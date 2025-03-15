using Microsoft.EntityFrameworkCore;
using June2023_technical.Models;

namespace June2023_technical.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BookModel>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}