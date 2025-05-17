using AutoMapper;

using LotsOfFun.Ui.Mvc.Models; // ViewModel
using LotsOfFun.Dto;
using LotsOfFun.Ui.Mvc.Models.People;

namespace LotsOfFun.Ui.Mvc.Mapping
{
    public class MvcMappingProfile : Profile
    {
        public MvcMappingProfile()
        {
            // ViewModel → DTO
            CreateMap<CreateEditPersonViewModel, UpdatePersonDto>();

            //DTO to viewmodel
            CreateMap<PersonDetailDto, PersonDetailViewModel>();
        }
    }
}
