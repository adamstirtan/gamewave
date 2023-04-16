using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Services
{
    public sealed class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(ApplicationDbContext context)
            : base(context)
        { }
    }
}