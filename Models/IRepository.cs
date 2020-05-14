using System.Linq;

namespace HelloDocker.Models
{
    public interface IRepository
    {
        public IQueryable<Product> Products { get; }

        public void Add(Product item);

        public void Delete(int id);
    }
}
