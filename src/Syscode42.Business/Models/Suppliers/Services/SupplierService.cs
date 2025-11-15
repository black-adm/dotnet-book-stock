using Syscode42.Business.Core.Notifications;
using Syscode42.Business.Core.Services;
using Syscode42.Business.Models.Suppliers.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Syscode42.Business.Models.Suppliers.Services
{
	public class SupplierService : BaseService, ISupplierService
	{
		private readonly ISupplerRepository _supplierRepository;
		private readonly IAddressRepository _addressRepository;

		public SupplierService(ISupplerRepository supplerRepository,
			IAddressRepository addressRepository, INotifier notifier) : base(notifier)
		{
			_supplierRepository = supplerRepository;
			_addressRepository = addressRepository;
		}

		public async Task AddAsync(Supplier supplier)
		{
			if (!ExecuteValidation(new SupplierValidation(), supplier)
				|| !ExecuteValidation(new AddressValidation(), supplier.Address))
				return;

			if (await SupplierAlreadyExist(supplier))
				return;

			await _supplierRepository.AddAsync(supplier);
		}

		public async Task UpdateAsync(Supplier supplier)
		{
			if (!ExecuteValidation(new SupplierValidation(), supplier))
				return;

			if (await SupplierAlreadyExist(supplier))
				return;

			await _supplierRepository.UpdateAsync(supplier);
		}

		public async Task DeleteAsync(Guid supplierId)
		{
			var supplier = await _supplierRepository.GetSupplierProductsAddressAsync(supplierId);

			if (supplier.Products.Any())
			{
				Notify("The supplier has registered products.");
				return;
			}

			if (supplier.Address != null)
				await _addressRepository.DeleteAsync(supplier.Address.Id);

			await _supplierRepository.DeleteAsync(supplierId);
		}

		public async Task UpdateAddressAsync(Address supplierAddress)
		{
			if (!ExecuteValidation(new AddressValidation(), supplierAddress))
				return;

			await _addressRepository.UpdateAsync(supplierAddress);
		}

		private async Task<bool> SupplierAlreadyExist(Supplier supplier)
		{
			var supplierAlreadyExist = await _supplierRepository.SearchAsync(s =>
				s.Document == supplier.Document && s.Id != supplier.Id);

			if (!supplierAlreadyExist.Any())
				return false;

			Notify("A supplier with this document number is already registered.");
			return true;
		}

		public void Dispose()
		{
			_supplierRepository?.Dispose();
			_addressRepository?.Dispose();
		}
	}
}
