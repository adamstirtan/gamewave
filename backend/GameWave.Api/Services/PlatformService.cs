using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(ApplicationDbContext context)
            : base(context)
        { }
    }
}