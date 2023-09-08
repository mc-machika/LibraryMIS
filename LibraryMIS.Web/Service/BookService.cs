using LibraryMIS.FrontEnd.Web.Models;
using LibraryMIS.Web.Models;
using LibraryMIS.Web.Service.IService;
using LibraryMIS.Web.Utility;


namespace LibraryMIS.Web.Service
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;
        public BookService(IBaseService baseService) 
        { 
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateBookAsync(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = bookDto,
                Url = StaticDetails.BookApiBase + "/api/BookApi"
            });
        }

        public async Task<ResponseDto?> DeleteBookAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/BookApi/" + id
            });
        }

        public async Task<ResponseDto?> GetAllBooksAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase+"/api/BookApi"
            });
        }

        public async Task<ResponseDto?> GetBookByIdAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/BookApi/" + id
            });
        }

        public async Task<ResponseDto?> UpdateBookAsync(BookDto bookDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = bookDto,
                Url = StaticDetails.BookApiBase + "/api/BookApi"
            });
        }
    }
}
