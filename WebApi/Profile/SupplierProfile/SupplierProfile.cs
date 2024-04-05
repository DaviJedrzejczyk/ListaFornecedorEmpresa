using Entities;
using WebApi.Models.SupplierModels;

namespace WebApi.Profile.SupplierProfile
{
    public class SupplierProfile : AutoMapper.Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierInsertViewModel, Supplier>();
            CreateMap<Supplier, SupplierInsertViewModel>();

            CreateMap<SupplierEditViewModel, Supplier>();
            //.ForPath(c => c.Company.CNPJ,
            //    x => x.MapFrom(src => src.Company.CNPJ))
            //.ForPath(c => c.Company.FantasyName,
            //    x => x.MapFrom(src => src.Company.FantasyName))
            //.ForPath(c => c.Company.UF,
            //    x => x.MapFrom(src => src.Company.UF));


            CreateMap<Supplier, SupplierEditViewModel>();
                //.ForPath(c => c.Company.CNPJ,
                //    x => x.MapFrom(src => src.Company.CNPJ))
                //.ForPath(c => c.Company.FantasyName,
                //    x => x.MapFrom(src => src.Company.FantasyName))
                //.ForPath(c => c.Company.UF,
                //    x => x.MapFrom(src => src.Company.UF));

            CreateMap<SupplierListViewModel, Supplier>()
                .ForPath(c => c.Company.CNPJ,
                    x => x.MapFrom(src => src.CnpjCompany))
                .ForPath(c => c.Company.FantasyName,
                    x => x.MapFrom(src => src.FantasyName))
                .ForPath(c => c.Company.UF,
                    x => x.MapFrom(src => src.UF));

            CreateMap<Supplier, SupplierListViewModel>()
            .ForPath(c => c.CnpjCompany,
                x => x.MapFrom(src => src.Company.CNPJ))
            .ForPath(c => c.FantasyName,
                x => x.MapFrom(src => src.Company.FantasyName))
            .ForPath(c => c.UF,
                x => x.MapFrom(src => src.Company.UF));
        }
    }
}
