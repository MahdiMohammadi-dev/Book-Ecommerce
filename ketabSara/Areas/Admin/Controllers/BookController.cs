using ketabSara.Areas.Admin.Models.Author;
using ketabSara.Areas.Admin.Models.Book;
using KetabSara.CoreLayer.DTO.Books;
using KetabSara.CoreLayer.Services.Authors;
using KetabSara.CoreLayer.Services.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var bookList = await _bookService.GetBookWithAuthors();
            List<BookWithAuthorViewModel>  books = new List<BookWithAuthorViewModel>();
            foreach (var bookWithAuthorDto in bookList)
            {
                var book = new BookWithAuthorViewModel()
                {
                    Title = bookWithAuthorDto.Title,
                    AuthorName = bookWithAuthorDto.AuthorName,
                    Description = bookWithAuthorDto.Description,
                    Id = bookWithAuthorDto.Id,
                    ImageName = bookWithAuthorDto.ImageName,
                    Price = bookWithAuthorDto.Price,
                };
                books.Add(book);
            }

            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAuthors();
            var authorViewModels = authors
                .Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Family = a.Family,
                })
                .ToList();

            var model = new CreateBookViewModel
            {
                AuthorsSelectList = new SelectList(authorViewModels, "Id", "FullName")
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                var authors = await _authorService.GetAuthors();
                var authorViewModels = authors
                    .Select(a => new AuthorViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Family = a.Family,
                    })
                    .ToList();

                var model = new CreateBookViewModel
                {
                    AuthorsSelectList = new SelectList(authorViewModels, "Id", "FullName")
                };
                bookViewModel.AuthorsSelectList = model.AuthorsSelectList;

                return View("Create",bookViewModel);
            }
            

            var bookDto = new CreateBookDto()
            {
                Title = bookViewModel.Title,
                Price = bookViewModel.Price,
                Description = bookViewModel.Description,
                AuthorId = bookViewModel.AuthorId,
                ImageName = bookViewModel.Img
            };
            await _bookService.Create(bookDto);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int id)
        {
           await _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
