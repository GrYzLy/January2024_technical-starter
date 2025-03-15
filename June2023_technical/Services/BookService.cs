using January2024_technical.Models;
using January2024_technical.Repositories;

namespace January2024_technical.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllAsync();
                return books;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books from the database.");
                throw new InvalidOperationException("An error occurred while retrieving the list of books.");
            }
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                _ = _bookRepository.DeleteAsync(book);
                await _bookRepository.SaveAsync();
            }
        }
    }
}
