using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		// DbContext
		private readonly ApplicationDbContext _db;
        // Repos
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }

		// Constructor
		public UnitOfWork(ApplicationDbContext db) 
        {
			_db = db;
			// instantiate for every repository of each entity
			Categories = new CategoryRepository(_db);
			Products = new ProductRepository(_db);
		}


		#region Methods
		public void Save()
		{
			_db.SaveChanges();
		}
		#endregion
	}
}
