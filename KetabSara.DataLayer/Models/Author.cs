using System.ComponentModel.DataAnnotations.Schema;

namespace KetabSara.DataLayer.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }



    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public ICollection<Book> Books { get; set; }

}