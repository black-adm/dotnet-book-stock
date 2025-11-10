using Syscode42.Business.Models.Suppliers;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syscode42.Infra.Data
{
    public class SupplierRepository : Repository<Supplier>, ISupplerRepository
    {
        public async Task<Supplier> GetSupplierByAddressAsync(Guid id)
        {
            return await Db.Suppliers
                .AsNoTracking()
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddressAsync(Guid id)
        {
            return await Db.Suppliers
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async override Task DeleteAsync(Guid id)
        {
            var supplier = await GetByIdAsync(id);
            supplier.IsActive = false;
            await UpdateAsync(supplier);
        }
    }
}
