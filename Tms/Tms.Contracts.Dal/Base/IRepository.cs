using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tms.Domain.Base;

namespace Tms.Contracts.Dal.Base
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : IEntity<TKey>
    {
        IList<TEntity> All();

        Task<IList<TEntity>> AllAsync();

        TEntity Get(TKey id);

        Task<TEntity> GetAsync(TKey id);

        TEntity FindOne(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression);

        IList<TEntity> FindMany(Expression<Func<TEntity, bool>> expression);

        Task<IList<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> expression);

        long Count();

        Task<long> CountAsync();

        bool Exists(Expression<Func<TEntity, bool>> expression);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

        void Delete(TKey id);   

        Task DeleteAsync(TKey id);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void DeleteAt(Expression<Func<TEntity, bool>> expression);

        Task DeleteAtAsync(Expression<Func<TEntity, bool>> expression);

        void DeleteAll();

        Task DeleteAllAsync();

        TEntity Create(TEntity entity);

        Task<TEntity> CreateAsync(TEntity entity);

        void Create(IEnumerable<TEntity> entities);

        Task CreateAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        Task UpdateAsync(IEnumerable<TEntity> entities);
    }
}