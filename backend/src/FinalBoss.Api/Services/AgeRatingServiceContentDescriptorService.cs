using FinalBoss.ObjectModel;

namespace FinalBoss.Api.Services
{
    public sealed class AgeRatingContentDescriptorService : BaseService<AgeRatingContentDescriptor>, IAgeRatingContentDescriptorService
    {
        public AgeRatingContentDescriptorService(ApplicationDbContext context)
            : base(context)
        { }
    }
}