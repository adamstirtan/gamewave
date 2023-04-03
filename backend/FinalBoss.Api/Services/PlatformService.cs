using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(ApplicationDbContext context)
            : base(context)
        { }
    }
}