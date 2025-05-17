using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LotsOfFun.Dto;
using LotsOfFun.Model;

namespace LotsOfFun.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            // DTO → Person (except address, which is mapped separately)
            CreateMap<UpdatePersonDto, Person>()
                .ForMember(dest => dest.Address, opt => opt.Ignore());

            // DTO → Address
            CreateMap<UpdatePersonDto, Address>();


            // Person -> PersonDetailDto 
            CreateMap<Person, PersonDetailDto>()
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src =>
                    $"{src.Address.Street} {src.Address.Number}{(string.IsNullOrWhiteSpace(src.Address.UnitNumber) ? "" : $" bus {src.Address.UnitNumber}")}, {src.Address.PostalCode} {src.Address.City}"));
        }
    }
}
