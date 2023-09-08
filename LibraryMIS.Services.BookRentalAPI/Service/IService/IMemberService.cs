using LibraryMIS.Services.BookRentalAPI.Models;
using LibraryMIS.Services.BookRentalAPI.Models.Dto;

namespace LibraryMIS.Services.BookRentalAPI.Service.IService
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetMember();
    }
}
