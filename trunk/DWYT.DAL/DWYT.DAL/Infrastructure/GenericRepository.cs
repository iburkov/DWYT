using System;
using System.Collections.Generic;
using DWYT.Core.DomainModels;
using DWYT.Core.Interfaces.RepositoryInterfaces;
using NHibernate;

namespace DWYT.DAL.Infrastructure
{
    /// <summary>
    /// Description of GenericRepositoryWithGuildKey.
    /// </summary>
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : DomainModel<TKey>, new()
    {
        public IList<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<T>();
                IList<T> entities = criteria.List<T>();
                return entities;
            }
        }

        public IList<T> GetAll(Func<T, bool> restriction)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var query = session.QueryOver<T>();
                IList<T> entities = query.Where(e => restriction(e)).List();
                return entities;
            }
        }

        public T Get(TKey key)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var query = session.QueryOver<T>();
                T entity = query.Where(e => e.Id.Equals(key)).SingleOrDefault();
                return entity;
            }
        }

        public T Get(Func<T, bool> restriction)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var query = session.QueryOver<T>();
                T entity = query.Where(e => restriction(e)).SingleOrDefault();
                return entity;
            }
        }

        public void Save(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }

        public void BatchInsert(IList<T> entities)
        {
            using (IStatelessSession session = NHibernateHelper.OpenStatelessSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        session.Insert(entity);
                    }
                    transaction.Commit();
                }
            }
        }

        public void BatchUpdate(IList<T> entities)
        {
            using (IStatelessSession session = NHibernateHelper.OpenStatelessSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        session.Update(entity);
                    }
                    transaction.Commit();
                }
            }
        }

        public void BatchSaveOrUpdate(IList<T> entities)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        session.SaveOrUpdate(entity);
                    }
                    transaction.Commit();
                }
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public void Delete(TKey key)
        {
            T obj = Get(key);
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }

        public void BatchDelete(IList<T> entities)
        {
            using (IStatelessSession session = NHibernateHelper.OpenStatelessSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        session.Delete(entity);
                    }
                    transaction.Commit();
                }
            }
        }

        public bool Exists(TKey key)
        {
            return Get(key) != null;
        }
    }
}
