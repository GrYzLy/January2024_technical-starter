using January2024_technical.Models;
using January2024_technical.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace January2024_technical.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository repository, ILogger<BookController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repository.GetAllAsync();  
            return View(books);
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
                    await _repository.AddAsync(book);
                    await _repository.SaveAsync();
                    TempData["SuccessMessage"] = "Book added successfully!";
                    return RedirectToAction("Index"); 
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while adding a book.");
                    return BadRequest("Couldn't create book!");
                }
                
            }
            return View(book);
        }

        [HttpPost]
        
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(book);
            await _repository.SaveAsync();

            TempData["SuccessMessage"] = "Book deleted successfully!";
            return RedirectToAction("Index"); 
        }
    }
}
