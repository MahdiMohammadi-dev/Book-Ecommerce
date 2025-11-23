using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetabSara.CoreLayer.DTO.Books
{
    public class BookWithAuthorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string ImageName { get; set; }
    }
}
