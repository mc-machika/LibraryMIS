using LibraryMIS.Services.MemberAPI.Models;

namespace LibraryMIS.Services.MemberAPI.Service.IService
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembersAsync();

        Task<Member> GetMemberAsync(string id);
        Task CreateMemberAsync(Member member);

        Task UpdateMemberAsync(Member member);

        Task RemoveMemberAsync(string id);
    }
}
