using AutoMapper;
using Company.BLL.DataTransferObjects.CompanyDto;
using Company.BLL.Services.Contracts;
using Company.DAL.RepositoryModels.Contracts;

namespace Company.BLL.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyServices(IMapper mapper, ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateCompany(CompanyForCreationDto companyForCreationDto)
        {
            if (companyForCreationDto == null) return false;
            var companyEntity = _mapper.Map<DAL.Models.Company>(companyForCreationDto);
            _companyRepository.CreateCompany(companyEntity);
            return true;
        }

        public async Task<bool> DeleteCompany(Guid companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            if (company == null) return false;
            _companyRepository.DeleteCompany(company);
            return true;
        }

        public async Task<IEnumerable<CompanyForGetDto>> GetAllCompany()
        {
            var companies = await _companyRepository.GetAllCompanyAsync();
            var companyDto = _mapper.Map<IEnumerable<CompanyForGetDto>>(companies);
            return companyDto;
        }

        public async Task<CompanyForGetDto> GetCompany(Guid companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            if (company == null) return null;
            var companyDto = _mapper.Map<CompanyForGetDto>(company);
            return companyDto;
        }

        public async Task<bool> UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdateDto)
        {
            var companyEntity = await _companyRepository.GetCompanyAsync(companyId);
            if (companyEntity == null) return false;

            _mapper.Map(companyForUpdateDto, companyEntity);
            _companyRepository.SaveCompany();
            return true;
        }
    }
}
