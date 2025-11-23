using KetabSara.CoreLayer.DTO.Authors;
using KetabSara.CoreLayer.DTO.Books;

namespace ketabSara.Areas.Admin.Models.Dashboard
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<AuthorDto> AuthorDtos { get; set; } = new List<AuthorDto>();
        public IEnumerable<BookWithAuthorDto> BookDtos { get; set; } = new List<BookWithAuthorDto>();
    }
}
