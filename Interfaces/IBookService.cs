using BookLibraryApi.Models;

namespace BookLibraryApi.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        // Define other operations here (Update, Delete)
    }
}
