using AutoMapper;
using Company.BLL.DataTransferObjects.CompanyDto;

namespace Company.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyForCreationDto, DAL.Models.Company>();

            CreateMap<DAL.Models.Company, CompanyForGetDto>();

            CreateMap<CompanyForUpdateDto, DAL.Models.Company>();

        }
    }
}
