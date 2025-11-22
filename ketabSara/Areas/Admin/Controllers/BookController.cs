using ketabSara.Areas.Admin.Models.Book;
using KetabSara.CoreLayer.DTO.Books;
using KetabSara.CoreLayer.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var bookList = await _bookService.GetBooks();
            List<BookViewModel> books = new List<BookViewModel>();
            foreach (var book in bookList)
            {
                books.Add(new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    price = book.Price
                });
            }

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",bookViewModel);
            }

            var bookDto = new CreateBookDto()
            {
                Title = bookViewModel.Title,
                Price = bookViewModel.Price,
                Description = bookViewModel.Description,
                Author = bookViewModel.Author,
                ImageName = "test",
            };
            await _bookService.Create(bookDto);
            return RedirectToAction("Index");
        }
    }
}
