using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KingsBooks.Models.DomainModels
{
    public class Genre
    {
        [StringLength(10)]
        [Required(ErrorMessage = "Please enter genre id")]
        public string GenreId { get; set; }


        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a genra name")]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
