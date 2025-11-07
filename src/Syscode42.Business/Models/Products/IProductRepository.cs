using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syscode42.Business.Core.Data;

namespace Syscode42.Business.Models.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplierAsync(Guid supplierId);
        Task<IEnumerable<Product>> GetProductsSuppliersAsync(Guid supplierId);
        Task<Product> GetProductSupplierAsync(Guid id);
    }
}