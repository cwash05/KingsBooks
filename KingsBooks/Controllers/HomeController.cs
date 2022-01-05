using KingsBooks.Models;
using KingsBooks.Models.DataLayer;
using KingsBooks.Models.DataLayer.Repositories;
using KingsBooks.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Book> data { get; set; }

        public HomeController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

        public IActionResult Index()
        {
            //get random book
            var random = data.Get(new QueryOptions<Book>
            {
                OrderBy = b => Guid.NewGuid()
            });

            return View(random);
        }

        public ContentResult Register()
        {
            return Content("Reg later");
        }

    }  

        
}
