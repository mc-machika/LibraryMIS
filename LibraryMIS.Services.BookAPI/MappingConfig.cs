using AutoMapper;
using LibraryMIS.Services.BookAPI.Models;
using LibraryMIS.Services.BookAPI.Models.Dto;

namespace LibraryMIS.Services.BookAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Book, BookDto>();
                config.CreateMap<BookDto, Book>();
            });

            return mappingConfiguration;
        }
    }
}
