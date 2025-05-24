using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LotsOfFun.Dto;
using LotsOfFun.Dto.Activity;
using LotsOfFun.Model;
using LotsOfFun.Services.Helper;

namespace LotsOfFun.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from UpdatePersonDto to Person entity (for updating a person in the DB)
            // Address is handled separately (ignored here)
            CreateMap<UpdatePersonDto, Person>()
                .ForMember(dest => dest.Address, opt => opt.Ignore());

            // Map from UpdatePersonDto to Address (used to update a person's address)
            CreateMap<UpdatePersonDto, Address>();

            // Map from Person to PersonDetailDto
            // FullAddress is built from multiple address fields using a helper method
            CreateMap<Person, PersonDetailDto>()
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => StringFormatter.FormatAddress(src.Address)));

            // Map from Activity entity to ActivityDto
            // - Location is simplified to Location.Name
            // - FullAddress is formatted using a helper method
            // - StartTime and EndTime are formatted as strings with a specific date/time pattern
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => StringFormatter.FormatAddress(src.Location.Address)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDate.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndDate.ToString("dd/MM/yyyy HH:mm")));

            // Uncomment this if you want a separate DTO for even more detailed activity views
            /*
            CreateMap<Activity, ActivityDetailDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => StringFormatter.FormatAddress(src.Location.Address)));
            */
        }
    }
}
