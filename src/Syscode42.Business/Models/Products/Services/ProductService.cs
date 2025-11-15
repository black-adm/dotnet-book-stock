using System;
using System.Threading.Tasks;
using Syscode42.Business.Core.Services;
using Syscode42.Business.Models.Products.Validations;

namespace Syscode42.Business.Models.Products.Services
{
	public class ProductService : BaseService, IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task AddAsync(Product product)
		{
			if (!ExecuteValidation(new ProductValidation(), product))
				return;

			await _productRepository.AddAsync(product);
		}

		public async Task UpdateAsync(Product product)
		{
			if (!ExecuteValidation(new ProductValidation(), product))
				return;

			await _productRepository.UpdateAsync(product);
		}

		public async Task DeleteAsync(Guid productId)
		{
			await _productRepository.DeleteAsync(productId);
		}

		public void Dispose()
		{
			_productRepository?.Dispose();
		}
	}
}
