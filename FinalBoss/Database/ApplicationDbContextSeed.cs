using System;

namespace FinalBoss.Database
{
    public class ApplicationDbContextSeed
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextSeed(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
        }
    }
}
