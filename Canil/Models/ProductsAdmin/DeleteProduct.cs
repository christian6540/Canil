using Canil.Models.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.ProductsAdmin
{
    public class DeleteProduct
    {
        private ApplicationsDbContext _context;

        public DeleteProduct(ApplicationsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Do(int id)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
