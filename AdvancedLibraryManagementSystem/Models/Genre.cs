using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvancedLibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
