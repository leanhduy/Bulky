using Bulky.Models;

// TODO: Delete this one once generic repository implemented
namespace Bulky.DataAccess.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Save();
        public void Update(Category category);
    }
}
