using BookStore.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class PurchaseCart
    {
        public int Id { get; set; }
        public DateTime datetime { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }

        public List<PurchaseCartItem> PurchaseCartItems { get; set; }

        public bool isOpen { get; set; }
    }
}
