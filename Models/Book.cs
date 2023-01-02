using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }

        public int Price { get; set; }

        public int discount { get; set; }
        public DateTime Created { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public List<BookImage> BookImages { get; set; }
        public List<PurchaseCartItem> PurchaseCartItems { get; set; }
    }
}
