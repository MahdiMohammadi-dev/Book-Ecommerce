using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetabSara.CoreLayer.DTO.Books
{
    public class PaginationBookDto
    {
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public List<BookDto> BookDtos { get; set; }
        
    }
}
