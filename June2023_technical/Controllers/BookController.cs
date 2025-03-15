using January2024_technical.Models;
using January2024_technical.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace January2024_technical.Controllers
{
    [Controller]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;

        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.Book.GetAll();

            if (books.Count() == 0)
            {
                _logger.LogError("No books found in the database.");

                return View("NoBooksFound");
            }

            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.Save();
                _logger.LogInformation($"Book with id {book.Id} has been added.");
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogError("Error while adding book.");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var bookToUpdate = _unitOfWork.Book.Get(u => u.Id == id);
            return View(bookToUpdate);
        }

        [HttpPatch]
        public IActionResult Update([FromBody]  Book book)
        {
            _unitOfWork.Book.Update(book);
            _unitOfWork.Save();
            _logger.LogInformation($"Book with id {book.Id} has been updated.");
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> bookList = _unitOfWork.Book.GetAll().ToList();
            return Json(new { data = bookList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var bookToBeDeleted = _unitOfWork.Book.Get(u => u.Id == id);
            if (bookToBeDeleted == null)
            {
                _logger.LogError($"Book with id {id} not found in the database.");
                return Json(new { success = false, message = "Error while deleteing" });
            }

            _unitOfWork.Book.Remove(bookToBeDeleted);
            _unitOfWork.Save();
            _logger.LogInformation($"Book with id {id} has been deleted.");

            return Json(new { success = true, message = "Book Deleted" });
        }
    }
}
