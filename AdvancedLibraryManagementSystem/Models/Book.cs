using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int PublishedYear { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}