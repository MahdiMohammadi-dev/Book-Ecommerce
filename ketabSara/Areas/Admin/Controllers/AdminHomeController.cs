using ketabSara.Areas.Admin.Models.Dashboard;
using KetabSara.CoreLayer.Services.Authors;
using KetabSara.CoreLayer.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminHomeController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AdminHomeController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public async  Task<IActionResult> Index()
        {
            var dashboardViewModel = new AdminDashboardViewModel
            {
                BookDtos =await _bookService.GetBookWithAuthors(),
                AuthorDtos = await _authorService.GetAuthors(),
            };
            return View(dashboardViewModel);
        }
    }
}
