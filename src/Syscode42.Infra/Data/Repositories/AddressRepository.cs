using Syscode42.Business.Models.Suppliers;
using System;
using System.Threading.Tasks;

namespace Syscode42.Infra.Data
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public async Task<Address> GetAddressBySupplierAsync(Guid supplierId)
        {
            return await GetByIdAsync(supplierId);
        }
    }
}
