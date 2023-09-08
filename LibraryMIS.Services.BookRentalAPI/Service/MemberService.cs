using LibraryMIS.Services.BookRentalAPI.Models.Dto;
using LibraryMIS.Services.BookRentalAPI.Service.IService;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LibraryMIS.Services.BookRentalAPI.Service
{
    public class MemberService : IMemberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MemberService(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IEnumerable<MemberDto>> GetMember()
        {
            var client = _httpClientFactory.CreateClient("Member");
            var response = await client.GetAsync($"/api/MemberApi");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<MemberDto>>(Convert.ToString(res.Result));
            }

            return new List<MemberDto>();
        }
    }
}
