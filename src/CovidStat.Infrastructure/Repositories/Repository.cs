using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidStat.Domain.Core.Entities;
using CovidStat.Domain.Core.Interfaces;
using CovidStat.Infrastructure.Context;
using CovidStat.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CovidStat.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public Repository(ApplicationDbContext dbContext)
        {
            Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = Db.Set<TEntity>();
        }

        protected ApplicationDbContext Db { get; }

        protected DbSet<TEntity> DbSet { get; }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<TEntity> GetByIdWithTracking(Guid id)
        {
            return await DbSet
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null) DbSet.Remove(entity);
        }

        

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void TryUpdateManyToMany<T, TKey>(IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class
        {
            Db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));
            Db.Set<T>().AddRange(newItems.Except(currentItems, getKey));

            Db.SaveChanges();
        }

        public void TryUpdateManyToMany<T, TKey>(IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class
        {
            IEnumerable<T> currentItems = new List<T>();
            Db.Set<T>().AddRange(newItems.Except(currentItems, getKey));

            Db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) Db.Dispose();
        }
    }
}
