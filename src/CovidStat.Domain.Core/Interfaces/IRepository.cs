using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStat.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(Guid id);

        Task<int> SaveChangesAsync();

        void TryUpdateManyToMany<T, TKey>(IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class;

        void TryUpdateManyToMany<T, TKey>(IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class;
    }
}