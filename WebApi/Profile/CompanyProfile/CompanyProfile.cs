using Entities;
using Entities.Enum;
using WebApi.Models.CompanyModels;

namespace WebApi.Profile.CompanyProfile
{
    public class CompanyProfile : AutoMapper.Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyInsertViewModel>();
            CreateMap<CompanyInsertViewModel, Company>();

            CreateMap<Company, CompanyEditViewModel>();
            CreateMap<CompanyEditViewModel, Company>();

            CreateMap<Company, CompanyListViewModel>().ForPath(c => c.UF, x => x.MapFrom(src => Enum.GetName(typeof(BrasilianEstates), src.UF)));
            CreateMap<CompanyListViewModel, Company>().ForPath(c => c.UF, x => x.MapFrom(src => Enum.GetName(typeof(BrasilianEstates), src.UF)));
        }

    }
}
