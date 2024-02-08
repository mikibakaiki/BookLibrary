namespace BookLibraryApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenres { get; set; } // Navigation property for many-to-many relationship
    }
}
