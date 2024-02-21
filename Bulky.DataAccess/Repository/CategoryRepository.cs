using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Category category)
		{
			// Add Specific update logic here...
			_db.Categories.Update(category);
		}
	}
}

