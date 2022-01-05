using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KingsBooks.Models.DomainModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]       
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        [MaxLength(200)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
