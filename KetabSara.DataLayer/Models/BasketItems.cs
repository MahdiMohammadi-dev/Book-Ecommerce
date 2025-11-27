using System.ComponentModel.DataAnnotations.Schema;

namespace KetabSara.DataLayer.Models
{
    public class BasketItems
    {
        public int Id { get; set; }
        
        
        
        public int BasketId { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }


        [ForeignKey("BasketId")]
        public Basket Basket { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

    }
}
