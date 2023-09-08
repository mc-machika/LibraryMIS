using LibraryMIS.Services.BookRentalAPI.Models;
using LibraryMIS.Services.BookRentalAPI.Models.Dto;
using Newtonsoft.Json;
using LibraryMIS.Services.BookRentalAPI.Service.IService;

namespace LibraryMIS.Services.BookRentalAPI.Service
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookService(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IEnumerable<BookDto>> GetBook()
        {
            var client = _httpClientFactory.CreateClient("Book");
            var response = await client.GetAsync($"/api/BookApi");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<BookDto>>(Convert.ToString(res.Result));
            }

            return new List<BookDto>();
        }
    }
}
