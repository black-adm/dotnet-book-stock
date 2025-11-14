using System.Threading.Tasks;
using System.Web.Mvc;
using Syscode42.Business.Models.Suppliers;
using Syscode42.Business.Models.Suppliers.Services;
using Syscode42.Infra.Data;

namespace Syscode42.AppMvc.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController()
        {
            _supplierService = new SupplierService(new SupplierRepository(), new AddressRepository());
		}

        public async Task<ActionResult> Index()
        {
            var supplier = new Supplier()
            {
                Name = "Matheus Madureira",
                Document = "47913149809",
                Address = new Address
                {
                    Street = "Praça da Sé",
                    AddressNumber = "777",
                    Neighborhood = "Sé",
                    PostalCode = "01001000",
                    Complement = "Lado Ímpar",
                    City = "São Paulo",
                    State = "São Paulo",
                },
                SupplierType = SupplierType.PF,
                IsActive = true,
			};

            await _supplierService.AddAsync(supplier);
            return new EmptyResult();
        }
    }
}