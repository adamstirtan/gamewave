using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Services
{
    public sealed class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(ApplicationDbContext context)
            : base(context)
        { }
    }
}