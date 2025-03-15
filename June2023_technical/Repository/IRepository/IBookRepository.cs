using January2024_technical.Models;

namespace January2024_technical.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
    }
}
