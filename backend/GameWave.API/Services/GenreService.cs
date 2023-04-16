using GameWave.API.Contracts;
using GameWave.ObjectModel;

namespace GameWave.API.Services
{
    public sealed class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(ApplicationDbContext context)
            : base(context)
        { }
    }
}