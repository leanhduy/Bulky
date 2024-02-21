using System;
using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
			// For Category, this.dbSet = _db.Set<Category> = The db set Categories in the ApplicationDbContext.cs
			_db.Products.Include(u => u.Category);
		}

		public T Get(Expression<Func<T, bool>> predicate, string? includeProps = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(predicate);
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(prop);
				}
			}
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includeProps = null)
		{
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(prop);
				}
			}
			return query.ToList();
		}

		public void Insert(T entity)
		{
			dbSet.Add(entity);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
