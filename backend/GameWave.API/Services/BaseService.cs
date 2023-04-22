using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using GameWave.API.Contracts;
using GameWave.API.Extensions;
using GameWave.ObjectModel;

namespace GameWave.API.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>, IServiceAsync<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<TEntity> Set;

        public BaseService(ApplicationDbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public virtual int Count()
        {
            return Set.Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).Count();
        }

        public virtual IQueryable<TEntity> All()
        {
            return Set;
        }

        public virtual IEnumerable<TEntity> Page(Expression<Func<TEntity, bool>> expression, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true)
        {
            return Set
                .OrderByPropertyOrField(sort, ascending)
                .Where(expression)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsQueryable();
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression);
        }

        public virtual TEntity GetById(long id)
        {
            return Set.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await Set.FindAsync(id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            _ = Set.Add(entity);

            var result = Context.SaveChanges() > 0;

            if (result)
            {
                return GetById(entity.Id);
            }

            return null;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _ = await Set.AddAsync(entity);

            var result = await Context.SaveChangesAsync() > 0;

            if (result)
            {
                return await GetByIdAsync(entity.Id);
            }

            return null;
        }

        public virtual bool Update(TEntity entity)
        {
            _ = Set.Update(entity);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _ = Set.Update(entity);

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual bool Delete(long id)
        {
            TEntity entity = GetById(id);

            if (entity is null)
            {
                return false;
            }

            _ = Set.Remove(entity);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            TEntity entity = GetById(id);

            if (entity is null)
            {
                return false;
            }

            _ = Set.Remove(entity);

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual bool Delete(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);

            return Context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}