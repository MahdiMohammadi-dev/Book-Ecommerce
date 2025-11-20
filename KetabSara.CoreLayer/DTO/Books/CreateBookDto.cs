namespace KetabSara.CoreLayer.DTO.Books;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ImageName { get; set; }
}