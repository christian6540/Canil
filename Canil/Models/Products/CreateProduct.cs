using System.Threading.Tasks;

namespace Canil.Models.Products
{
    public class CreateProduct
    {
        private ApplicationsDbContext _context;

        public CreateProduct(ApplicationsDbContext context)
        {
            _context = context;
        }

        public async Task Do(string Name, string Description, decimal Value)
        {
            _context.Products.Add(new Product
            {
                Name = Name,
                Description = Description,
                Value = Value
            });

            await _context.SaveChangesAsync();
        }

    }
}
