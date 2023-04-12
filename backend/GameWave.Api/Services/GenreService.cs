using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public sealed class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(ApplicationDbContext context)
            : base(context)
        { }
    }
}