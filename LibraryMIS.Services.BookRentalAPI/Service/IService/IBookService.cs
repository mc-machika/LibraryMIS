using LibraryMIS.Services.BookRentalAPI.Models;

namespace LibraryMIS.Services.BookRentalAPI.Service.IService
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBook();
    }
}
