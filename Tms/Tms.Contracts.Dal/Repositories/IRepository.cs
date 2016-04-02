using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tms.Domain.Base;

namespace Tms.Contracts.Dal.Repositories
{
    public interface IRepository<T, in TKey> : IDisposable 
        where T : IEntity<TKey>
    {
        IList<T> All();

        Task<IList<T>> AllAsync();

        IQueryable<T> All(int skip, int take);

        Task<IQueryable<T>> AllAsync(int skip, int take);

        T Get(TKey id);

        Task<T> GetAsync(TKey id);

        T Unique(Expression<Func<T, bool>> expression);

        Task<T> UniqueAsync(Expression<Func<T, bool>> expression);

        IList<T> List(Expression<Func<T, bool>> expression);

        IList<T> ListAsync(Expression<Func<T, bool>> expression);

        long Count();

        Task<long> CountAsync();

        bool Exists(Expression<Func<T, bool>> expression);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        void Delete(TKey id);   

        Task DeleteAsync(TKey id);

        void Delete(T item);

        Task DeleteAsync(T item);

        void DeleteAt(Expression<Func<T, bool>> expression);

        Task DeleteAtAsync(Expression<Func<T, bool>> expression);

        void DeleteAll();

        Task DeleteAllAsync();

        void Add(T item);

        Task AddAsync(T item);

        void Add(IEnumerable<T> items);

        Task AddAsync(IEnumerable<T> items);

        void Update(T item);

        Task UpdateAsync(T item);

        void Update(IEnumerable<T> items);

        Task UpdateAsync(IEnumerable<T> items);
    }
}