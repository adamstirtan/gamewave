using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(ApplicationDbContext context)
            : base(context)
        { }
    }
}