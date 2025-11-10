using Syscode42.Business.Models.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Syscode42.Infra.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId)
        {
            return await SearchAsync(p => p.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliersAsync(Guid supplierId)
        {
            return await Db.Products
                .AsNoTracking()
                .Include(s => s.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product> GetProductSupplierAsync(Guid id)
        {
            return await Db.Products
                .AsNoTracking()
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
