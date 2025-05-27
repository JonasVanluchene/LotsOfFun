using AutoMapper;
using LotsOfFun.Dto;
using LotsOfFun.Dto.Activity;
using LotsOfFun.Ui.Mvc.Models.Activity;
using LotsOfFun.Ui.Mvc.Models.People;

namespace LotsOfFun.Ui.Mvc.Mapping
{
    public class MvcMappingProfile : Profile
    {
        public MvcMappingProfile()
        {
            // Map from CreateEditPersonViewModel (form input) to UpdatePersonDto
            // Used when submitting forms to update a person
            CreateMap<CreateEditPersonViewModel, UpdatePersonDto>();

            // Map from PersonDetailDto to PersonDetailViewModel
            // Used to display detailed information about a person in the UI
            CreateMap<PersonDetailDto, PersonDetailViewModel>();




            // Map from ActivityDto to ActivityViewModel
            // Used to render activity summary info in activity listings
            CreateMap<ActivityDto, ActivityViewModel>();

            // Map from ActivityDto to ActivityDetailsViewModel
            // Used to render full activity details in the detail view
            CreateMap<ActivityDto, ActivityDetailsViewModel>();


            CreateMap<CreateEditActivityViewModel, ActivityCreateDto>()
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate.ToDateTime(src.StartTime)))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.StartDate.ToDateTime(src.EndTime)))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.Ignore()) // since it's null on create
                .ForMember(dest => dest.LocationId,
                    opt => opt.MapFrom(src => src.SelectedLocationId))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description ?? string.Empty));


            CreateMap<ActivityDto, CreateEditActivityViewModel>()
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Parse(src.StartTime))))
                .ForMember(dest => dest.StartTime,
                    opt => opt.MapFrom(src => TimeOnly.FromDateTime(DateTime.Parse(src.StartTime))))
                .ForMember(dest => dest.EndTime,
                    opt => opt.MapFrom(src => TimeOnly.FromDateTime(DateTime.Parse(src.EndTime))))
                .ForMember(dest => dest.SelectedLocationId,
                    opt => opt.MapFrom(src => src.LocationId));

        }
    }
}
