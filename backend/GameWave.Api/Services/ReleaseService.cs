using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class ReleaseService : BaseService<Release>, IReleaseService
    {
        public ReleaseService(ApplicationDbContext context)
            : base(context)
        { }
    }
}

