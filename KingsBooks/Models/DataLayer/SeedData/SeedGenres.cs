using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingsBooks.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingsBooks.Models.DataLayer.SeedData
{
    public class SeedGenres : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre { GenreId = "novel,", Name = "Novel" },
                new Genre { GenreId = "memoir,", Name = "Memoir" },
                new Genre { GenreId = "mystery,", Name = "Mystery" },
                new Genre { GenreId = "syfi,", Name = "Science Fiction" },
                new Genre { GenreId = "history,", Name = "History" }
                );
        }
    }
}
