using System;
using System.Collections.Generic;
using System.Linq;

namespace DWYT.Core.Interfaces.RepositoryInterfaces
{
	/// <summary>
	/// Description of IGenericRepository.
	/// </summary>
	public interface IGenericRepository<T, in TKey>
	{
		IList<T> GetAll();

        IList<T> GetAll(Func<T, bool> restriction);
		
		T Get(TKey key);

        T Get(Func<T, bool> restriction);
		
		void Save(T entity);
		
		void BatchInsert(IList<T> entities);

        void BatchUpdate(IList<T> entities);

        void BatchSaveOrUpdate(IList<T> entities);
		
		void Delete(T entity);
		
		void Delete(TKey key);
		
		void BatchDelete(IList<T> entities);
		
		bool Exists(TKey key);
	}
}
