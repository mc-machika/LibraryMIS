using LibraryMIS.Web.Models;
using LibraryMIS.Web.Models.Dto;
using LibraryMIS.Web.Service.IService;
using LibraryMIS.Web.Utility;

namespace LibraryMIS.Web.Service
{
    public class MemberService : IMemberService
    {
        private readonly IBaseService _baseService;
        public MemberService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateMemberAsync(MemberDto memberDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = memberDto,
                Url = StaticDetails.MemberApiBase + "/api/MemberApi"
            });
        }

        public async Task<ResponseDto?> DeleteMemberAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.MemberApiBase + "/api/MemberApi/" + id
            });
        }

        public async Task<ResponseDto?> GetAllMembersAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.MemberApiBase + "/api/MemberApi"
            });
        }

        public async Task<ResponseDto?> GetMemberByIdAsync(string id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.MemberApiBase + "/api/MemberApi/" + id
            });
        }

        public async Task<ResponseDto?> UpdateMemberAsync(MemberDto memberDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = memberDto,
                Url = StaticDetails.MemberApiBase + "/api/MemberApi" + memberDto.Id
            });
        }
    }
}
