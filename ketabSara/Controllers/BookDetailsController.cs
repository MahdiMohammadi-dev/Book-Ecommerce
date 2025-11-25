using KetabSara.CoreLayer.Services.Books;
using ketabSara.Models;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly IBookService _bookService;

        public BookDetailsController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(int id)
        {
            var entity = _bookService.GetBookById(id);
            if(entity==null)
                return NotFound();
            var bookVm = new BookViewModel()
            {
                Id = entity.Result.Id,
                Title = entity.Result.Title,
                Price = entity.Result.Price,
                Description = entity.Result.Description,
                ImageName = entity.Result.ImageName,
                AuthorName = entity.Result.AuthorName
            };
            return View("BookDetails",bookVm);
        }
    }
}
