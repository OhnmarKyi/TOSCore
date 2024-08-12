using TOSCore.Context;
using TOSCore.Models;

namespace TOSCore.Interfaces
{
    public interface IRegistrationService
    {
        public Task<List<MBrand>> GetBrand();
        public Task<List<MCompany>> GetCompany();
        public Task<object> InsertCompany(M_CompanyModel mModel);
    }
}
