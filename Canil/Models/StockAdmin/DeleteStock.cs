using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.StockAdmin
{
    public class DeleteStock
    {
        private ApplicationsDbContext _ctx;

        public DeleteStock(ApplicationsDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var stock = _ctx.Stock.FirstOrDefault(x => x.Id == id);
            _ctx.Stock.Remove(stock);

            await _ctx.SaveChangesAsync();
            return true;
        }

    }
}
