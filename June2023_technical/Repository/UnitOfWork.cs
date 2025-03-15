using January2024_technical.DataAccess;
using January2024_technical.Repository.IRepository;

namespace January2024_technical.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public BookContext _bookContext { get; private set; }
        public IBookRepository Book { get; private set; }

        public UnitOfWork(BookContext bookContext)
        {
            _bookContext = bookContext;
            Book = new BookRepository(_bookContext);
        }

        public void Save()
        {
            _bookContext.SaveChanges();
        }
    }
}
