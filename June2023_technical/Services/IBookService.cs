using January2024_technical.Models;

namespace January2024_technical.Services
{
    public interface IBookService
    {
        Task AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task DeleteBookAsync(int id);
    }
}
