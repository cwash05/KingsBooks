using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsBooks.Models.DTOs;
using KingsBooks.Models.DomainModels;
using KingsBooks.Models.ExtensionMethods;


namespace KingsBooks.Models.Grid
{
    public class BooksGridBuilder : GridBuilder
    {
        public BooksGridBuilder(ISession sess) : base (sess) { }

        public BooksGridBuilder(ISession sess, BookGridDTO values, string defaultSortFilter) : base(sess, values, defaultSortFilter)
        {
            bool isInitial = values.Genre.IndexOf(FilterPrefix.Genre) == -1;
            Routes.AutherFilter = (isInitial) ? FilterPrefix.Author + values.Author : values.Author;
            Routes.GenreFilter = (isInitial) ? FilterPrefix.Genre + values.Genre : values.Genre;
            Routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;

            SaveRouteSegment();
        }

        // load new filter routes segmets contained in a string array

        public void LoadFilterSegmentes(string[] filter, Author author)
        {
            if (author == null)
                Routes.AutherFilter = FilterPrefix.Author + filter[0];
            else
                Routes.AutherFilter = FilterPrefix.Author + filter[0] + "-" + author.FullName.Slug();

            Routes.GenreFilter = FilterPrefix.Genre + filter[1];
            Routes.PriceFilter = FilterPrefix.Price + filter[2];
        }

        public void ClearFilterSegmentes() => Routes.ClearFilters();

        string def = BookGridDTO.DefaultFilter;
        public bool IsFilterByAuthor => Routes.AutherFilter != def;
        public bool IsFilterByGenra => Routes.GenreFilter != def;
        public bool IsFilterByPrice => Routes.PriceFilter != def;


        public bool  IsSortbyGenre => Routes.SortField.EqualsNoCase(nameof(Genre));
        public bool IsSortByPrice => Routes.SortField.EqualsNoCase(nameof(Book.Price));


    }
}
