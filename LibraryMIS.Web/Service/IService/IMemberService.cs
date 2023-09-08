using LibraryMIS.Web.Models;
using LibraryMIS.Web.Models.Dto;

namespace LibraryMIS.Web.Service.IService
{
    public interface IMemberService
    {
        Task<ResponseDto?> GetAllMembersAsync();
        Task<ResponseDto?> GetMemberByIdAsync(string id);
        Task<ResponseDto?> CreateMemberAsync(MemberDto memberDto);
        Task<ResponseDto?> UpdateMemberAsync(MemberDto memberDto);
        Task<ResponseDto?> DeleteMemberAsync(string id);
    }
}
