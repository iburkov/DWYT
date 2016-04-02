using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tms.Common.Constants;
using Tms.Configuration;
using Tms.Contracts.Dal.Repositories;
using Tms.Domain.Base;

namespace Tms.Dal.MongoDb.Repositories
{
    public class MongoRepository<T, TKey> : IRepository<T, TKey> 
        where T : IEntity<TKey>
    {

        public MongoRepository(IConfigProvider config)
            : this(config.GetConnectionString(ConfigKeys.DefaultConnectionString))
        {
            
        }

        public MongoRepository(string connectionString)
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<T> All()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> AllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public T Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public T Unique(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> UniqueAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<T> ListAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAt(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAtAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}