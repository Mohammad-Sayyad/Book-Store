using BookStore.Models;

namespace BookStore.ViewModel
{
    public class GroupByGenreViewModel
    {
        public string GenreName { get; set; }
        public int GenreId { get; set; }
        public List<Book> Books { get; set; }

    }
}
