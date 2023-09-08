using LibraryMIS.Services.BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMIS.Services.BookAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Book>().HasData(new Book
            //{
            //    Id = 1,
            //    Title = "The Lord of the Rings",
            //    ISBN = "9780007525546",
            //    Author = "J. R. R. Tolkien",
            //    State = "Available",
            //    Source = "Amazon"
            //});

            //modelBuilder.Entity<Book>().HasData(new Book
            //{
            //    Id = 2,
            //    Title = "The Hobbit",
            //    ISBN = "9780007525546",
            //    Author = "J. R. R. Tolkien",
            //    State = "Available",
            //    Source = "Amazon"
            //});
        }
    }
}
