using Bulky.Models;

// TODO: Delete this one once generic repository implemented
namespace Bulky.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category category);
    }
}
