using AutoMapper;
using Company.BLL.DataTransferObjects.CompanyDto;

namespace Company.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Models.Company, CompanyForCreationDto>();

            CreateMap<DAL.Models.Company, CompanyForGetDto>();

            CreateMap<DAL.Models.Company, CompanyForUpdateDto>();

        }
    }
}
