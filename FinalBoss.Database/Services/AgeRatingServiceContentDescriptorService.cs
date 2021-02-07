using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class AgeRatingContentDescriptorService : BaseService<AgeRatingContentDescriptor>, IAgeRatingContentDescriptorService
    {
        public AgeRatingContentDescriptorService(ApplicationDbContext context)
            : base(context)
        { }
    }
}