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
        }
    }
}
