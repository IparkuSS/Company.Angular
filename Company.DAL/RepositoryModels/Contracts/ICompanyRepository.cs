namespace Company.DAL.RepositoryModels.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Models.Company>> GetAllCompanyAsync();

        Task<Models.Company> GetCompanyAsync(Guid companyId);

        void CreateCompany(Models.Company company);

        void DeleteCompany(Models.Company company);

        void SaveCompany();
    }
}
