using LibraryMIS.Services.BookRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMIS.Services.BookRentalAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<Rental> rentals { get; set; }
    }
}
