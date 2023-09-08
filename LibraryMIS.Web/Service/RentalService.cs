using LibraryMIS.FrontEnd.Web.Models.Dto;
using LibraryMIS.Web.Models;
using LibraryMIS.Web.Service.IService;

namespace LibraryMIS.Web.Service
{
    public class RentalService : IRentalService
    {
        public Task<ResponseDto?> CreateRentalAsync(RentalDto rentalDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteRentalAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllRentalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetRentalByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateRentalAsync(RentalDto rentalDto)
        {
            throw new NotImplementedException();
        }
    }
}
