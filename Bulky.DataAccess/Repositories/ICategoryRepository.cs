using Bulky.Models;

namespace Bulky.DataAccess.Repositories
{
	public interface ICategoryRepository
	{
		// Save Changes
		public void Save();
		// CRUD
		public IEnumerable<Category> GetAllCategories();
		public Category? GetCategoryById(int id);
		public void InsertCategory(Category category);
		public void UpdateCategory(Category category);
		public void DeleteCategory(int id);
	}
}
