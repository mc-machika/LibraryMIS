using LibraryMIS.Services.AuthAPI.Models;

namespace LibraryMIS.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
