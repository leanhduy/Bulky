using System.Linq.Expressions;

namespace Bulky.DataAccess.IRepository
{
    /// <summary>
    /// The generic interface in the Generic Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
    {
        // CRUD
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T, bool>> predicate);
        public void Insert(T entity);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);

        // (Others - Based on busness requirements)
    }
}
