using System.ComponentModel.DataAnnotations;

namespace ketabSara.Areas.Admin.Models.Author
{
    public class CreateAuthorViewModel
    {
        [Required(ErrorMessage = "نام نویسنده را وارد کنید")]
        [Display(Name = "نام نویسنده")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی نویسنده را وارد کنید")]
        [Display(Name = "نام خانوادگی نویسنده")]

        public string Family { get; set; }
    }
}
