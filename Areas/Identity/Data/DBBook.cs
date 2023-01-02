using BookStore.Areas.Identity.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class DBBook : IdentityDbContext<ApplicationUser>
{
    public DBBook(DbContextOptions<DBBook> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookImage> BookImages { get; set; }

    public DbSet<PurchaseCart> PurchaseCarts { get; set; }
    public DbSet<PurchaseCartItem> PurchaseCartItems { get; set; }

}
