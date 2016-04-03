using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tms.Contracts.Dal.Base;
using Tms.Domain.Base;

namespace Tms.Dal.MongoDb.Base
{
    public abstract class MongoRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        protected IMongoCollection<TEntity> Collection => Database.GetCollection<TEntity>(typeof(TEntity).Name);

        protected IMongoDatabase Database { get; }

        protected MongoRepositoryBase(IMongoDatabase database)
        {
            Database = database;
        }

        public IList<TEntity> All()
        {
            return Collection.AsQueryable().ToList();
        }

        public async Task<IList<TEntity>> AllAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public TEntity Get(TKey id)
        {
            return Collection
                .Find(x => x.Id.Equals(id))
                .SingleOrDefault();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return Collection
                .Find(x => x.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.Find(expression).SingleOrDefault();
        }

        public Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.Find(expression).SingleOrDefaultAsync();
        }

        public IList<TEntity> FindMany(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.Find(expression).ToList();
        }

        public async Task<IList<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Collection.Find(expression).ToListAsync();
        }

        public long Count()
        {
            return Collection.Count(FilterDefinition<TEntity>.Empty);
        }

        public Task<long> CountAsync()
        {
            return Collection.CountAsync(FilterDefinition<TEntity>.Empty);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.FindSync(expression) != null;
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Collection.FindAsync(expression) != null;
        }

        public void Delete(TKey id)
        {
            Collection.DeleteOne(e => e.Id.Equals(id));
        }

        public Task DeleteAsync(TKey id)
        {
            return Collection.DeleteOneAsync(e => e.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            Delete(entity.Id);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return DeleteAsync(entity.Id);
        }

        public void DeleteAt(Expression<Func<TEntity, bool>> expression)
        {
            Collection.DeleteMany(expression);
        }

        public Task DeleteAtAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.DeleteManyAsync(expression);
        }

        public void DeleteAll()
        {
            this.Database.DropCollection(typeof(TEntity).Name);
        }

        public Task DeleteAllAsync()
        {
            return this.Database.DropCollectionAsync(typeof(TEntity).Name);
        }

        public TEntity Create(TEntity entity)
        {
            Collection.InsertOne(entity);

            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);

            return entity;
        }

        public void Create(IEnumerable<TEntity> entities)
        {
            Collection.InsertMany(entities);
        }

        public Task CreateAsync(IEnumerable<TEntity> entities)
        {
            return Collection.InsertManyAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Collection.ReplaceOne(
                e => e.Id.Equals(entity.Id),
                entity
            );

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Collection.ReplaceOneAsync(
                e => e.Id.Equals(entity.Id),
                entity
            );

            return entity;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}