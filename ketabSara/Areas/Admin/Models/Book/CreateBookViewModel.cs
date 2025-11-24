
using System.ComponentModel.DataAnnotations;
using ketabSara.Areas.Admin.Models.Author;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ketabSara.Areas.Admin.Models.Book
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنید")]
        [Display(Name = "عنوان کتاب")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [Display(Name = "توضیحات کتاب")]
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [Display(Name = "نویسنده کتاب")]
        public int AuthorId { get; set; }
        public SelectList? AuthorsSelectList { get; set; }

        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [Display(Name = "قیمت کتاب")]
        public int Price { get; set; }
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [Display(Name = "عکس کتاب")]
        public IFormFile Img { get; set; }

    }
}
