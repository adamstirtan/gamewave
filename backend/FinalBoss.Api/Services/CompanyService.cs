using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(ApplicationDbContext context)
            : base(context)
        { }
    }
}