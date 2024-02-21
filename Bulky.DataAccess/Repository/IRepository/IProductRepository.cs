using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product>
    {
        public void Update(Product product);
    }
}
