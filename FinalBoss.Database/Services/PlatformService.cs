using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(ApplicationDbContext context)
            : base(context)
        { }
    }
}