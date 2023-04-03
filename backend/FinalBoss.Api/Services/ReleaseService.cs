using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class ReleaseService : BaseService<Release>, IReleaseService
    {
        public ReleaseService(ApplicationDbContext context)
            : base(context)
        { }
    }
}

