using AutoMapper;
using LibraryMIS.Services.BookRentalAPI.Models;
using LibraryMIS.Services.BookRentalAPI.Models.Dto;

namespace LibraryMIS.Services.BookRentalAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RentalDto, Rental>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
