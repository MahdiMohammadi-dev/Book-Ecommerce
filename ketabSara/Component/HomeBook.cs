using ketabSara.Models;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Component
{
    public class HomeBook:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<BookViewModel> models)
        {
            return View("HomeBook",models);
        }
    }
}
