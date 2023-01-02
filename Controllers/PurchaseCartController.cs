using BookStore.Areas.Identity.Data;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class PurchaseCartController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        DBBook db;
        public PurchaseCartController (UserManager<ApplicationUser> userManager , DBBook dB)
        {
            UserManager = userManager;
            db = dB;
        }

        public async Task<bool> AddToCart1(int bookid , int count)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            PurchaseCart purchaseCart = db.PurchaseCarts.FirstOrDefault(x => x.isOpen && x.CustomerId == user.Id);
            if(purchaseCart == null)
            {
                purchaseCart = new PurchaseCart
                {
                    datetime = DateTime.Now,
                    CustomerId = user.Id,
                    isOpen = true
                };
                db.Add(purchaseCart);
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
            }

            PurchaseCartItem purchaseCartItem = new PurchaseCartItem
            {
                BookId = bookid,
                count = count,
                PurchaseCartId = purchaseCart.Id
            };
            db.Add(purchaseCartItem);
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }
    }
}
