using January2024_technical.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace January2024_technical.DataAccess
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookContext>() ?? throw new InvalidOperationException("Failed to retriev Application Context");

            SeedData(context);
        }

        private static void SeedData(BookContext context)
        {
            context.Database.Migrate();

            if (context.Books.Any()) return;

            var books = new List<Book>
            {
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicatiionYear = 1925, Genre = "Fiction", Price = 25 },
                new Book { Title = "Hobbit", Author = "J. R.R. Tolkien", PublicatiionYear = 1955, Genre = "Fiction", Price = 20 },
                new Book { Title = "1984", Author = "George Orwell", PublicatiionYear = 1949, Genre = "Dystopian", Price = 15 },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicatiionYear = 1960, Genre = "Fiction", Price = 18 },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", PublicatiionYear = 1813, Genre = "Romance", Price = 12 },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicatiionYear = 1925, Genre = "Fiction", Price = 10 },
                new Book { Title = "Moby Dick", Author = "Herman Melville", PublicatiionYear = 1851, Genre = "Adventure", Price = 22 },
                new Book { Title = "War and Peace", Author = "Leo Tolstoy", PublicatiionYear = 1869, Genre = "Historical Fiction", Price = 25 },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicatiionYear = 1951, Genre = "Fiction", Price = 14 },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", PublicatiionYear = 1932, Genre = "Dystopian", Price = 16 },
                new Book { Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", PublicatiionYear = 1954, Genre = "Fantasy", Price = 30 },
                new Book { Title = "The Alchemist", Author = "Paulo Coelho", PublicatiionYear = 1988, Genre = "Adventure", Price = 18 },
                new Book { Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", PublicatiionYear = 1890, Genre = "Philosophical Fiction", Price = 15 },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", PublicatiionYear = 1953, Genre = "Dystopian", Price = 17 },
                new Book { Title = "The Chronicles of Narnia", Author = "C.S. Lewis", PublicatiionYear = 1950, Genre = "Fantasy", Price = 20 },
                new Book { Title = "The Grapes of Wrath", Author = "John Steinbeck", PublicatiionYear = 1939, Genre = "Historical Fiction", Price = 19 },
                new Book { Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", PublicatiionYear = 1979, Genre = "Science Fiction", Price = 15 },
                new Book { Title = "The Road", Author = "Cormac McCarthy", PublicatiionYear = 2006, Genre = "Post-Apocalyptic", Price = 22 },
                new Book { Title = "The Fault in Our Stars", Author = "John Green", PublicatiionYear = 2012, Genre = "Young Adult", Price = 12 },
                new Book { Title = "The Book Thief", Author = "Markus Zusak", PublicatiionYear = 2005, Genre = "Historical Fiction", Price = 18 },
                new Book { Title = "The Kite Runner", Author = "Khaled Hosseini", PublicatiionYear = 2003, Genre = "Drama", Price = 16 },
                new Book { Title = "Life of Pi", Author = "Yann Martel", PublicatiionYear = 2001, Genre = "Adventure", Price = 14 }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
