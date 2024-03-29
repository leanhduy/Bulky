﻿using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The generic interface in the Generic Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
    {
        // CRUD
        public IEnumerable<T> GetAll(string? includeProps = null);
        public T Get(Expression<Func<T, bool>> predicate, string? includeProps = null);
        public void Insert(T entity);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);

        // (Others - Based on busness requirements)
    }
}
