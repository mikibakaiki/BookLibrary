using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Models;

namespace BookLibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", YearPublished = 1925 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", YearPublished = 1960 },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", YearPublished = 1949 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
