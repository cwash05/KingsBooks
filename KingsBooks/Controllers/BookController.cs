using KingsBooks.Models.DataLayer;
using KingsBooks.Models.DataLayer.Repositories;
using KingsBooks.Models.DomainModels;
using KingsBooks.Models.DTOs;
using KingsBooks.Models.ExtensionMethods;
using KingsBooks.Models.Grid;
using KingsBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KingsBooks.Controllers
{
    public class BookController : Controller
    {
        private BookUoW Data { get; set; }
        public BookController(BookstoreContext ctx) => Data = new BookUoW(ctx);
        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(BookGridDTO values)
        {
            var builder = new BooksGridBuilder(HttpContext.Session, values, defaultSortFilter: nameof(Book.Title));

            var options = new BookQueryOptions
            {
                Includes = "BookAuthors.Author, Genre",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize

            };

            options.SortFilter(builder);


            var vm = new BookListViewModel
            {
                Books = Data.Books.List(options),
                Authors = Data.Authors.List(new QueryOptions<Author> { OrderBy = a => a.LastName }),
                Genres = Data.Genres.List(new QueryOptions<Genre> { OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(Data.Books.Count)
            };

            return View(vm);
        }
        
        public ViewResult Details(int id)
        {
            var book = Data.Books.Get(new QueryOptions<Book>
            {
                Includes = "BookAuthors.Author, Genre",
                Where = b => b.BookId == id
            });

            return View(book);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new BooksGridBuilder(HttpContext.Session);

            if (clear)
                builder.ClearFilterSegmentes();
            else
            {
                var author = Data.Authors.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegmentes(filter, author);

            }

            builder.SaveRouteSegment();
            return RedirectToAction("List", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new BooksGridBuilder(HttpContext.Session);
            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegment();

            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
