using ketabSara.Areas.Admin.Models.Author;
using KetabSara.CoreLayer.DTO.Authors;
using KetabSara.CoreLayer.Services.Authors;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task <IActionResult> Index()
        {
            var authorList = await _authorService.GetAuthors();
            List<AuthorViewModel> authorListViewModel = new List<AuthorViewModel>();
            foreach (var author in authorList)
            {
                authorListViewModel.Add(new AuthorViewModel
                    {
                        Id = author.Id,
                        Name = author.Name,
                        Family = author.Family,

                    }
                );
            }

            return View(authorListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorViewModel authorViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Create",authorViewModel);
            }
            var author = new CreateAuthorDto()
            {
                Name = authorViewModel.Name,
                Family = authorViewModel.Family
            };
           await _authorService.Create(author);
           return RedirectToAction("Index");
        }
    }
}
