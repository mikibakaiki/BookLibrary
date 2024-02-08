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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Author seed
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "F. Scott Fitzgerald" },
                new Author { Id = 2, Name = "Harper Lee" },
                new Author { Id = 3, Name = "George Orwell" },
                new Author { Id = 4, Name = "George R. R. Martin" },
                new Author { Id = 5, Name = "J. R. R. Tolkien" },
                new Author { Id = 6, Name = "Leo Tolstoy" },
                new Author { Id = 7, Name = "Jane Austen" },
                new Author { Id = 8, Name = "Mark Twain" },
                new Author { Id = 9, Name = "Charles Dickens" },
                new Author { Id = 10, Name = "J.K. Rowling" },
                new Author { Id = 11, Name = "Ernest Hemingway" },
                new Author { Id = 12, Name = "H.G. Wells" },
                new Author { Id = 13, Name = "Ray Bradbury" },
                new Author { Id = 14, Name = "Agatha Christie" },
                new Author { Id = 15, Name = "Stephen King" }
            );

            // Genre seed
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Classic" },
                new Genre { Id = 2, Name = "Fantasy" },
                new Genre { Id = 3, Name = "Science Fiction" },
                new Genre { Id = 4, Name = "Mystery" },
                new Genre { Id = 5, Name = "Thriller" },
                new Genre { Id = 6, Name = "Historical" }
            );

            // Book seed
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", AuthorId = 1, YearPublished = 1925 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", AuthorId = 2, YearPublished = 1960 },
                new Book { Id = 3, Title = "1984", AuthorId = 3, YearPublished = 1949 },
                new Book { Id = 4, Title = "A Song of Ice and Fire", AuthorId = 4, YearPublished = 1996 },
                new Book { Id = 5, Title = "The Lord Of The Rings", AuthorId = 5, YearPublished = 1954 },
                // New books
                new Book { Id = 6, Title = "War and Peace", AuthorId = 6, YearPublished = 1869 },
                new Book { Id = 7, Title = "Pride and Prejudice", AuthorId = 7, YearPublished = 1813 },
                new Book { Id = 8, Title = "The Adventures of Huckleberry Finn", AuthorId = 8, YearPublished = 1884 },
                new Book { Id = 9, Title = "Great Expectations", AuthorId = 9, YearPublished = 1861 },
                new Book { Id = 10, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 10, YearPublished = 1997 },
                new Book { Id = 11, Title = "The Old Man and the Sea", AuthorId = 11, YearPublished = 1952 },
                new Book { Id = 12, Title = "The War of the Worlds", AuthorId = 12, YearPublished = 1898 },
                new Book { Id = 13, Title = "Fahrenheit 451", AuthorId = 13, YearPublished = 1953 },
                new Book { Id = 14, Title = "Murder on the Orient Express", AuthorId = 14, YearPublished = 1934 },
                new Book { Id = 15, Title = "The Shining", AuthorId = 15, YearPublished = 1977 }
            );

            // Many-to-many: BookGenre
            modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            // BookGenre seed (associating books with genres)
            modelBuilder.Entity<BookGenre>().HasData(
                // Associate "The Great Gatsby" with "Classic"
                new BookGenre { BookId = 1, GenreId = 1 },
                // Associate "A Song of Ice and Fire" with "Fantasy"
                new BookGenre { BookId = 4, GenreId = 2 },
                // Associate "The Lord Of The Rings" with "Fantasy"
                new BookGenre { BookId = 5, GenreId = 2 }
                // You can add more associations as needed
            );
        }
    }
}
