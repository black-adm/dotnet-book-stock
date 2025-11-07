using System;
using System.Threading.Tasks;
using Syscode42.Business.Core.Data;

namespace Syscode42.Business.Models.Suppliers
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressBySupplierAsync(Guid supplierId);
    }
}