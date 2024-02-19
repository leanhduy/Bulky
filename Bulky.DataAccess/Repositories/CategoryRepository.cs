using Bulky.DataAccess.Data;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _db;

		// Inject DbContext class via constructor inject
		public CategoryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public void DeleteCategory(int id)
		{
			Category? category = GetCategoryById(id);
			if (category == null) return;
			_db.Remove(category);
		}

		public IEnumerable<Category> GetAllCategories()
		{
			return _db.Categories;
		}

		public Category? GetCategoryById(int id)
		{
			return _db.Categories.Find(id);
		}

		public void InsertCategory(Category category)
		{
			_db.Add(category);
		}

		public void Save()
		{
			_db.SaveChanges();
		}

		public void UpdateCategory(Category category)
		{
			_db.Update(category);
		}
	}
}
