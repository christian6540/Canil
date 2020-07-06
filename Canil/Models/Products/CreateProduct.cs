using Canil.Models.Products;
using System.Threading.Tasks;

namespace Canil.Models.CreateProducts
{
    public class CreateProduct
    {
        private ApplicationsDbContext _context;

        public CreateProduct(ApplicationsDbContext context)
        {
            _context = context;
        }

        public async Task Do(ProductViewModel vm)
        {
            _context.Products.Add(new Product
            {
                Name = vm.Name,
                Description = vm.Description,
                Value = vm.Value
            });

            await _context.SaveChangesAsync();
        }
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
