using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Services
{
    public sealed class ReleaseService : BaseService<Release>, IReleaseService
    {
        public ReleaseService(ApplicationDbContext context)
            : base(context)
        { }
    }
}

