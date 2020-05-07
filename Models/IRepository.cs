using System.Linq;

namespace HelloDocker.Models
{
    public interface IRepository
    {
        public IQueryable<Product> Products { get; }
    }
}
