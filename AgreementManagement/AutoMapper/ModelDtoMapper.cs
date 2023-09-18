using AgreementManagement.Dto;
using ams.DataAccess.Database.Entity;
using ams.Models.ViewModel;
using AutoMapper;

namespace AgreementManagement.AutoMapper
{
    public class ModelDtoMapper : Profile
    {
        public ModelDtoMapper()
        {
            CreateMap<VendorAgreement, VendorAgreementVM>();
            CreateMap<VendorAgreementDto, VendorAgreement>();
        }
    }
}
