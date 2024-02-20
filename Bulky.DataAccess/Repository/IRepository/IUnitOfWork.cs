namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		// Declare all the repository for all models in the application
		#region Repos
		public ICategoryRepository Categories { get; }
		// (later when we add Product)
		// public IProductRepository 
		#endregion

		#region Methods
		public void Save();
		// TODO: Later some advanced methods for transaction will be added, such as RollBack(), Commit(), etc. Keep only Save() now for simplicity
		#endregion

	}
}
