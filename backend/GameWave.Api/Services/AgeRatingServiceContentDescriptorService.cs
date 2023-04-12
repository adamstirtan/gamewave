using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class AgeRatingContentDescriptorService : BaseService<AgeRatingContentDescriptor>, IAgeRatingContentDescriptorService
    {
        public AgeRatingContentDescriptorService(ApplicationDbContext context)
            : base(context)
        { }
    }
}