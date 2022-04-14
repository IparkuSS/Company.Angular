using Company.DAL.RepositoryModels.Contracts;
using Company.DAL.Setting;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.RepositoryModels
{
    public class CompanyRepository : RepositoryBase<Models.Company>, ICompanyRepository
    {
        private readonly TrackSettings _trackSettings;
        public CompanyRepository(RepositoryContext repositoryContext, TrackSettings trackSettings) : base(repositoryContext) { _trackSettings = trackSettings; }
        public void CreateCompany(Models.Company company) => Create(company);
   
        public void DeleteCompany(Models.Company company) => Delete(company);

        public async Task<IEnumerable<Models.Company>> GetAllCompanyAsync() =>
            await FindAll(_trackSettings.TrackChanges)
                .OrderBy(c => c.Country).ToListAsync();

        public async Task<Models.Company> GetCompanyAsync(Guid companyId) =>
            await FindByCondition(c => c.Id.Equals(companyId), _trackSettings.TrackChanges)
                .SingleOrDefaultAsync();
        public void SaveCompany() => Save();
    }
}
