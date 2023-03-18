using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(ApplicationDbContext context)
            : base(context)
        { }
    }
}