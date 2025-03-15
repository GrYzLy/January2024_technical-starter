using January2024_technical.Models;
using January2024_technical.Repositories;
using January2024_technical.Services;
using Microsoft.AspNetCore.Mvc;

namespace January2024_technical.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
           _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return View(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the list of books.");
                TempData["ErrorMessage"] = "Couldn't load books!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.AddBookAsync(book);
                    TempData["SuccessMessage"] = "Book added successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while adding a book.");
                    TempData["ErrorMessage"] = "Couldn't create book!";
                    return RedirectToAction("Index");
                }
            }

            return View(book);
        }

        [HttpPost]
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                await _bookService.DeleteBookAsync(id);

                TempData["SuccessMessage"] = "Book deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book.");
                TempData["ErrorMessage"] = "Couldn't delete book!";
                return RedirectToAction("Index");
            }
        }
    }
}
