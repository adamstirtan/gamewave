using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Services
{
    public sealed class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(ApplicationDbContext context)
            : base(context)
        { }
    }
}