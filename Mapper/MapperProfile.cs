using AutoMapper;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;
using TaskCRUDCleanDI.DTO;
using TaskCRUDCleanDI.Models;

namespace TaskCRUDCleanDI.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => "Not specified"))
                .ReverseMap();
        }
    }
}
