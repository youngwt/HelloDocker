using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HelloDocker.Models
{
    public class Repository : IRepository
    {
        private ProductDbContext _context;

        public Repository(ProductDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Product> Products => _context.Products;

        public void Add (Product item)
        {
            _context.Products.Add(item);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);

            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }
    };
}
