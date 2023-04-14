using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using GameWave.Api.Extensions;
using GameWave.ObjectModel;

namespace GameWave.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ApplicationUser> _set;

        public UserService(ApplicationDbContext context)
            : base()
        {
            _context = context;
            _set = _context.Set<ApplicationUser>();
        }

        public int Count()
        {
            return _set.Count();
        }

        public int Count(Expression<Func<ApplicationUser, bool>> expression)
        {
            return _set.Where(expression).Count();
        }

        public IQueryable<ApplicationUser> All()
        {
            return _set;
        }

        public IEnumerable<ApplicationUser> Page(Expression<Func<ApplicationUser, bool>> expression, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true)
        {
            return _set
                .OrderByPropertyOrField(sort, ascending)
                .Where(expression)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsQueryable();
        }

        public IEnumerable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> expression)
        {
            return _set.Where(expression);
        }

        public ApplicationUser GetById(string id)
        {
            return _set.Find(id);
        }

        public async ValueTask<ApplicationUser> GetByIdAsync(string id)
        {
            return await _set.FindAsync();
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            _ = _set.Add(user);

            var result = _context.SaveChanges() > 0;

            if (result)
            {
                return GetById(user.Id);
            }

            return null;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser entity)
        {
            _ = await _set.AddAsync(entity);

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
            {
                return await GetByIdAsync(entity.Id);
            }

            return null;
        }

        public bool Update(ApplicationUser entity)
        {
            _ = _set.Update(entity);

            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(ApplicationUser entity)
        {
            _ = _set.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public bool Delete(string id)
        {
            ApplicationUser user = GetById(id);

            if (user is null)
            {
                return false;
            }

            _ = _set.Remove(user);

            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            ApplicationUser user = GetById(id);

            if (user is null)
            {
                return false;
            }

            _ = _set.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }

        public bool Delete(IEnumerable<ApplicationUser> entities)
        {
            _set.RemoveRange(entities);

            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(IEnumerable<ApplicationUser> entities)
        {
            _set.RemoveRange(entities);

            return await _context.SaveChangesAsync() > 0;
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            return _context.Users.Find(userName);
        }

        public async ValueTask<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FindAsync(userName);
        }
    }
}