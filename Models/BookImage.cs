using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class BookImage
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public byte[] ImgThumbnail { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        
    }
}
