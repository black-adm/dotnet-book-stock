using System;
using System.Threading.Tasks;

namespace Syscode42.Business.Models.Products.Services
{
    public interface IProductService : IDisposable
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid productId);
    }
}
