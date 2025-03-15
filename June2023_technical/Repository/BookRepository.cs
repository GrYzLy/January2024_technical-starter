using January2024_technical.DataAccess;
using January2024_technical.Models;
using January2024_technical.Repository.IRepository;

namespace January2024_technical.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext bookContext) : base(bookContext)
        {
            _bookContext = bookContext;
        }

        public void Update(Book book)
        {
            _bookContext.Update(book);
        }
    }
}
