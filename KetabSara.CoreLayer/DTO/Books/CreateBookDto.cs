using Microsoft.AspNetCore.Http;

namespace KetabSara.CoreLayer.DTO.Books;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int AuthorId { get; set; }
    public IFormFile ImageName { get; set; }
}