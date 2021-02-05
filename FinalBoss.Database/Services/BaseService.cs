using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using FinalBoss.ObjectModel;
using FinalBoss.Shared.Extensions;

namespace FinalBoss.Database.Services
{
    public abstract class BaseService<T> : IService<T>, IServiceAsync<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> Set;

        public BaseService(ApplicationDbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public virtual int Count()
        {
            return Set.Count();
        }

        public virtual IQueryable<T> All()
        {
            return Set;
        }

        public virtual IEnumerable<T> Page(Func<T, bool> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true)
        {
            return Set
                .Where(query)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .OrderByPropertyOrField(sort)
                .AsQueryable();
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Set.Where(expression);
        }

        public virtual T GetById(long id)
        {
            return Set.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await Set.FindAsync(id);
        }

        public virtual T Create(T entity)
        {
            _ = Set.Add(entity);

            var result = Context.SaveChanges() > 0;

            if (result)
            {
                return GetById(entity.Id);
            }

            return null;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _ = await Set.AddAsync(entity);

            var result = await Context.SaveChangesAsync() > 0;

            if (result)
            {
                return await GetByIdAsync(entity.Id);
            }

            return null;
        }

        public virtual bool Update(T entity)
        {
            _ = Set.Update(entity);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _ = Set.Update(entity);

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual bool Delete(long id)
        {
            T entity = GetById(id);

            if (entity is null)
            {
                return false;
            }

            _ = Set.Remove(entity);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            T entity = GetById(id);

            if (entity is null)
            {
                return false;
            }

            _ = Set.Remove(entity);

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}