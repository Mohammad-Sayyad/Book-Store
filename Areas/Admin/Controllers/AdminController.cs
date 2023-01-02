using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;


namespace BookStore.Areas.Admin.Controllers
{

    [Area("admin")]
    [Authorize(Policy ="AdminPolicy")]
    public class AdminController : Controller
    {
       
        public IActionResult index()
        {
            return View();
        }

        public IActionResult BookList(int id, [FromServices] DBBook db)
        {
            List<Book> books = db.Books.Include(x => x.Genre).Include(x => x.BookImages).ToList();
            return View(books);
        }
        public IActionResult InsertBook([FromServices] DBBook db)
        {
            ViewData["Genres"] = db.Genres.ToList();
            return View();
        }

        public IActionResult InsertBookConfirm(BookViewModel model, [FromServices] DBBook db)
        {
            Book book = new Book
            {
                Name = model.Name,
                Price = model.Price,
                discount = model.discount,
                Writer = model.Writer,
                Publisher = model.Publisher,
                GenreId = model.GenreId,
                Created = model.Created,
                BookImages = new List<BookImage>()
            };
            model.Img.ForEach(x =>
            {
                if (Path.GetExtension(x.FileName.ToLower()) == ".jpg")
                {
                    if (x.Length <= 10 * 1024 * 1024)
                    {
                        byte[] b = new byte[x.Length];
                        x.OpenReadStream().Read(b, 0, b.Length);
                        BookImage bookImage = new BookImage();
                        bookImage.Img = b;
                        MemoryStream memoryStream = new MemoryStream(b);
                        Image image = Image.FromStream(memoryStream);
                        Bitmap bitmap = new Bitmap(image, 200, 200);
                        MemoryStream memoryStream2 = new MemoryStream();
                        bitmap.Save(memoryStream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bookImage.ImgThumbnail = memoryStream2.ToArray();
                        book.BookImages.Add(bookImage);
                    }
                }

            });
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("InsertBook", "Book");
        }
    }
}
