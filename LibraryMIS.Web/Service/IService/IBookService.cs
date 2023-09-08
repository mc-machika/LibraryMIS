using LibraryMIS.FrontEnd.Web.Models;
using LibraryMIS.Web.Models;

namespace LibraryMIS.Web.Service.IService
{
    public interface IBookService
    {
        Task<ResponseDto?> GetAllBooksAsync();
        Task<ResponseDto?> GetBookByIdAsync(string id);
        Task<ResponseDto?> CreateBookAsync(BookDto bookDto);
        Task<ResponseDto?> UpdateBookAsync(BookDto bookDto);
        Task<ResponseDto?> DeleteBookAsync(string id);
    }
}
