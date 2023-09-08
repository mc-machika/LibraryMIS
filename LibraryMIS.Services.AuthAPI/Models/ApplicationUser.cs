using Microsoft.AspNetCore.Identity;

namespace LibraryMIS.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
