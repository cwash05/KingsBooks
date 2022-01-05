using KingsBooks.Models.DomainModels;
using KingsBooks.Models.ExtensionMethods;
using KingsBooks.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Models.DataLayer
{
    public class BookQueryOptions : QueryOptions<Book>
    {
        public void SortFilter(BooksGridBuilder builder)
        {
            if (builder.IsFilterByGenra)
                Where = b => b.GenreId == builder.CurrentRoute.GenreFilter;

            if (builder.IsFilterByPrice)
            {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.Price < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.Price >= 7 && b.Price <= 14;
                else
                    Where = b => b.Price > 14;
            }

            if (builder.IsFilterByAuthor)
            {
                int id = builder.CurrentRoute.AutherFilter.ToInt();

                if (id > 0)
                    Where = b => b.BookAuthors.Any(ba => ba.AuthorId == id);
            }


            if (builder.IsSortbyGenre)
                OrderBy = b => b.Genre.Name;
            else if (builder.IsSortByPrice)
                OrderBy = b => b.Price;
            else
                OrderBy = b => b.Title;
        }
    }
   
}
