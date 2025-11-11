using System;
using System.Threading.Tasks;

namespace Syscode42.Business.Models.Suppliers.Services
{
    public interface ISupplierService : IDisposable
    {
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Guid supplierId);
        Task UpdateAddressAsync(Address supplierAddress);
    }
}
