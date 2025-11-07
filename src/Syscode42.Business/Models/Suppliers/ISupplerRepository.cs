using System;
using System.Threading.Tasks;
using Syscode42.Business.Core.Data;

namespace Syscode42.Business.Models.Suppliers
{
    public interface ISupplerRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierByAddressAsync(Guid id);
        Task<Supplier> GetSupplierProductsAddressAsync(Guid id);
    }
}