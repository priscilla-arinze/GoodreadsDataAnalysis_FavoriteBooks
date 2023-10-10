using System.ComponentModel.DataAnnotations;

namespace BooksWebApp.Models
{
    public class FavoriteBook
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        public FavoriteBook()
        {
            
        }
    }
}
