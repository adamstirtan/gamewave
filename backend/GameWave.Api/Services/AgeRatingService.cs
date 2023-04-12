using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class AgeRatingService : BaseService<AgeRating>, IAgeRatingService
    {
        public AgeRatingService(ApplicationDbContext context)
            : base(context)
        { }
    }
}