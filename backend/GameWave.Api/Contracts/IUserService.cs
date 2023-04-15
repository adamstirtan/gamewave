using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface IUserService
    {
        int Count();

        int Count(Expression<Func<ApplicationUser, bool>> expression);

        IQueryable<ApplicationUser> All();

        IEnumerable<ApplicationUser> Page(Expression<Func<ApplicationUser, bool>> expression, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true);

        IEnumerable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> expression);

        ApplicationUser GetById(string id);

        ApplicationUser Create(ApplicationUser user);

        bool Update(ApplicationUser user);

        bool Delete(string id);

        bool Delete(IEnumerable<ApplicationUser> users);

        ValueTask<ApplicationUser> GetByIdAsync(string id);

        Task<ApplicationUser> CreateAsync(ApplicationUser user);

        Task<bool> UpdateAsync(ApplicationUser user);

        Task<bool> DeleteAsync(string id);

        Task<bool> DeleteAsync(IEnumerable<ApplicationUser> users);
    }
}