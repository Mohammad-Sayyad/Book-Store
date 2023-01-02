using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class PurchaseCartItem
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int count { get; set; }

        public int PurchaseCartId { get; set; }
        [ForeignKey("PurchaseCartId")]
        public PurchaseCart PurchaseCart { get; set; }
    }
}
