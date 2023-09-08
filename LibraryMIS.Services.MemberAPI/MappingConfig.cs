using AutoMapper;
using LibraryMIS.Services.MemberAPI.Models;
using LibraryMIS.Services.MemberAPI.Models.Dto;

namespace LibraryMIS.Services.MemberAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Member, MemberDto>();
                config.CreateMap<MemberDto, Member>();
            });

            return mappingConfiguration;
        }
    }
}
