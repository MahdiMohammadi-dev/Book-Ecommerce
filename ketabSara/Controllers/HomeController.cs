using KetabSara.CoreLayer.Services.Books;
using ketabSara.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _bookService.GetBookWithAuthors();
            List<BookViewModel> books = new List<BookViewModel>();
            foreach (var book in list)
            {
                var entity = new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = (int)book.Price,
                    ImageName = book.ImageName,
                    AuthorName = book.AuthorName,
                    Description = book.Description
                };
                books.Add(entity);
            }

            return View("Index",books);
        }

        public IActionResult AllProducts()
        {

            return View();
        }
        [Authorize]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
