using Company.BLL.DataTransferObjects.CompanyDto;

namespace Company.BLL.Services.Contracts
{
    public interface ICompanyServices
    {
        Task<IEnumerable<CompanyForGetDto>> GetAllCompany();

        Task<CompanyForGetDto> GetCompany(Guid companyId);

        Task<bool> CreateCompany(CompanyForCreationDto companyForCreationDto);

        Task<bool> DeleteCompany(Guid companyId);

        Task<bool> UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdateDto);
    }
}
