namespace BookStore.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Writer { get; set; }
        public string Publisher { get; set; }

        public int Price { get; set; }

        public int discount { get; set; }
        public DateTime Created { get; set; }

        public int GenreId { get; set; }

        public List<IFormFile> Img { get; set; }

    }
}
