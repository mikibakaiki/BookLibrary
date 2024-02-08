namespace BookLibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int AuthorId { get; set; } // Foreign key
        public Author Author { get; set; } // Navigation property
        public List<BookGenre> BookGenres { get; set; } // Navigation property for many-to-many relationship
    }
}