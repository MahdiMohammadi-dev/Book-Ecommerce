using System.ComponentModel.DataAnnotations.Schema;

namespace KetabSara.DataLayer.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ImageName { get; set; }

    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }


    public ICollection<BasketItems>? BasketItemsList { get; set; }


}