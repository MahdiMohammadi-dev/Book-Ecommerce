using System.ComponentModel.DataAnnotations.Schema;
using KetabSara.DataLayer.Enums;

namespace KetabSara.DataLayer.Models;

public class Basket
{
    public int Id { get; set; }
    public DateTime Created { get; set; }


    public int UserId { get; set; }
    public string Address { get; set; }
    public Status Status { get; set; }

    
    
    [ForeignKey("UserId")]
    public User? User { get; set; }

    public ICollection<BasketItems>? BasketItemsList { get; set; }

}