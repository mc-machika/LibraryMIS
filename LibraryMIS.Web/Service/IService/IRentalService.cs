using LibraryMIS.FrontEnd.Web.Models;
using LibraryMIS.FrontEnd.Web.Models.Dto;
using LibraryMIS.Web.Models;

namespace LibraryMIS.Web.Service.IService
{
    public interface IRentalService
    {
        Task<ResponseDto?> GetAllRentalsAsync();
        Task<ResponseDto?> GetRentalByIdAsync(int id);
        Task<ResponseDto?> CreateRentalAsync(RentalDto rentalDto);
        Task<ResponseDto?> UpdateRentalAsync(RentalDto rentalDto);
        Task<ResponseDto?> DeleteRentalAsync(int id);
    }
}
