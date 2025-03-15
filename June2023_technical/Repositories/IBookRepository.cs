using January2024_technical.Models;

namespace January2024_technical.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);

        Task AddAsync(Book book);

        Task SaveAsync();

        Task<IEnumerable<Book>> GetAllAsync();

        Task DeleteAsync(Book book);
    }
}
