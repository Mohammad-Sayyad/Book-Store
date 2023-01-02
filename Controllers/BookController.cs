using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BookStore.Controllers
{
   
    public class BookController : Controller
    {
        DBBook db;
        public BookController(DBBook _db)
        {
            db = _db;
        }

        public IActionResult index()
        {

            return View(db.Books.Include(x=> x.BookImages).ToList());
        }

       
        public IActionResult GroupByGenre([FromServices] DBBook db)
        {
            List<GroupByGenreViewModel> model = db.Books.GroupBy(x => x.GenreId)
                .Select(x =>
                new GroupByGenreViewModel
                {
                    GenreId = x.Key,
                    Books = x.ToList()
                }).ToList();



            return View(model);
        }
        
    }
}
