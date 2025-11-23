namespace ketabSara.Areas.Admin.Models.Book
{
    public class BookWithAuthorViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string ImageName { get; set; }
    }
}
