using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KingsBooks.Models.DomainModels
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Range(0.0,1000000.0, ErrorMessage ="Price must be more than 0 and less than 1 million")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Please select a genre")]
        public string GenreId { get; set; }

        public Genre Genre { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
