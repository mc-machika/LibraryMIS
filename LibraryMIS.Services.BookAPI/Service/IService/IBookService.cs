using LibraryMIS.Services.BookAPI.Models;

namespace LibraryMIS.Services.BookAPI.Service.IService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookAsync(string id);

        Task CreateBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task RemoveBookAsync(string id);
    }
}
